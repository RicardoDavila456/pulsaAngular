using System;
using System.Collections.Generic;
using Datos;
using Entidad;
using System.Linq;

namespace Logica
{
    public class PersonaService
    {
        private readonly PulsacionesContext _context;

        public PersonaService(PulsacionesContext context){
            _context = context;
        }

        public GuardarPersonaResponse Guardar(Persona persona){
            try{
                var personaBuscada = _context.Personas.Find(persona.Identificacion);
                if(personaBuscada != null){
                    return new GuardarPersonaResponse("Error la persona ya esta registrada :)");
                }
                persona.CalcularPulsaciones();
                _context.Personas.Add(persona);
                _context.SaveChanges();
                return new GuardarPersonaResponse(persona);
            }catch(Exception e){
                return new GuardarPersonaResponse($"Error de la aplicacion : {e.Message}");
            }
        }

        public ConsultarPersonaResponse ConsultarTodos(){
            try{
                List<Persona> personas=_context.Personas.ToList();
                if(personas!=null){
                    return new ConsultarPersonaResponse(personas);
                }else{
                    return new ConsultarPersonaResponse("no se encuentran registros actualmente :(");
                }
            }catch(Exception e){
                return new ConsultarPersonaResponse($"Error de la aplicacion : {e.Message}");
            }
        }
        
        public string Eliminar(string identificacion){
            try{
                var persona =_context.Personas.Find(identificacion);
                if(persona == null){
                    _context.Personas.Remove(persona);
                    _context.SaveChanges();
                    return ($"la persona {persona.Nombre} se ha eliminado correctamente");
                }else{
                    return ($"la persona {persona.Nombre} no se encuentra registrada :v");
                }
            }catch(Exception e){
                return $"Error de la aplicacion: {e.Message}";
            }
        }
    
        public string Modificar(Persona personaNueva){
            try{
                var personaVieja = _context.Personas.Find(personaNueva.Identificacion);
                if(personaVieja!=null){
                    personaVieja.Nombre=personaNueva.Nombre;
                    personaVieja.Identificacion=personaNueva.Identificacion;
                    personaVieja.Sexo=personaNueva.Sexo;
                    personaVieja.Edad=personaNueva.Edad;
                    personaVieja.CalcularPulsaciones();
                    _context.Personas.Update(personaVieja);
                    _context.SaveChanges();
                    return ($"El registro {personaNueva.Nombre} se a modificado correctamente");
                }else{
                    return ($"la persona {personaNueva.Identificacion} no se encuentra registrada");
                }
            }catch (Exception e){
                return ($"Error de la aplicacion : {e.Message}");
            }
        }
    }
    

    public class GuardarPersonaResponse 
    {
        public GuardarPersonaResponse(Persona persona)
        {
            Error = false;
            Persona = persona;
        }
        public GuardarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Persona Persona { get; set; }
    }
    
    public class ConsultarPersonaResponse 
    {
        public ConsultarPersonaResponse(List<Persona> personas)
        {
            Error = false;
            Personas=new List<Persona>();
            Personas= personas;
        }
        public ConsultarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Persona> Personas { get; set; }
    }
}


