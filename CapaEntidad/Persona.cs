using System;

namespace CapaEntidad
{
    public class Persona
    {
        public int Id_Persona { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Licencia { get; set; }
        public bool Estado { get; set; }

        // Relación a Dirección
        public Domicilio oDomicilio { get; set; } = new Domicilio();

        public DateTime Fecha_Nacimiento { get; set; }
    }
}
