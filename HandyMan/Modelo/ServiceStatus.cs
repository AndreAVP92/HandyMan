using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ServiceStatus
    {
        public int      Id          { get; set; }
        public string   Description { get; set; } //En espera, Cancelado, Reparando, Finalizado, 
        public bool     State       { get; set; }
    }
}
