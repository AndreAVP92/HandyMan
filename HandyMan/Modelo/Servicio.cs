using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Servicio
    {
        public int      Id            { get; set; }
        public Usuario  Cliente       { get; set; }
        public Usuario  Profesional   { get; set; }
        public string   Direccion     { get; set; }
        public string   Descripcion   { get; set; }
        public double   Importe       { get; set; }
        public DateTime FechaContrato { get; set; }
        public EstadoContrato EstadoContrato { get; set; }
        public Pago     Pago          { get; set; }
        public bool     Estado        { get; set; }
    }
}
