using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using pulsacionesdotnet.Models;

namespace pulsacionesdotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonaController : ControllerBase{
        private readonly PersonaService _personaService;
        public PersonaController(PulsacionesContext context)
        {
            _personaService=new PersonaService(context);
        }


        [HttpGet]
        public IEnumerable<PersonaViewModel> Gets()
        {
        var personas = _personaService.ConsultarTodos().Personas.Select(p=> new PersonaViewModel(p));
        return personas;
        }


        [HttpPost]
        public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
        {
        Persona persona = MapearPersona(personaInput);
        var response = _personaService.Guardar(persona);
        if (response.Error)
        {
        return BadRequest(response.Mensaje);
        }
        return Ok(response.Persona);
        }

        // DELETE: api/Persona/5
        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
        string mensaje = _personaService.Eliminar(identificacion);
        return Ok(mensaje);
        }

        private Persona MapearPersona(PersonaInputModel personaInput)
        {
        var persona = new Persona
        {
        Identificacion = personaInput.Identificacion,
        Nombre = personaInput.Nombre,
        Edad = personaInput.Edad,
        Sexo = personaInput.Sexo
        };
        return persona;
        }
    }
}