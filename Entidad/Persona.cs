using System;

namespace Entidad
{
    public class Persona
    {
        public string Identificacion { get; set;}
        public string Nombre { get; set;}
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public decimal Pulsacion { get; set; }
        public void CalcularPulsaciones()
        {
            if(Sexo.Equals("Femenino")){
                Pulsacion=(220-Edad)/10;
            }else
            {
                Pulsacion=(210-Edad)/10;
            }
        }
    }
}
