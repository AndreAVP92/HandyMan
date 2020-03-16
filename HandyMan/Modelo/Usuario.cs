using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {
        public int        Id              { get; set; }
        public Foto       Id_Foto         { get; set; }
        public string     Nombre          { get; set; }
        public int        Telefono        { get; set; }
        public string     Email           { get; set; }
        public string     Password        { get; set; }
        public string     EstadoConexion  { get; set; }
        public DateTime   FechaRegistro   { get; set; }
        public Valoracion Valoracion      { get; set; }
        public Rol        Rol             { get; set; }
        public string     Estado          { get; set; } //Dado de baja, de alta, suspendido 
    }   
}
