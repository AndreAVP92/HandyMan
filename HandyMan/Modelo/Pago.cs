using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Pago
    {
        public int      Id          { get; set; }
        public string   Descripcion { get; set; }
        public bool     Estado      { get; set; }
    }
}
