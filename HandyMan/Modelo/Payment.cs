using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Payment
    {
        public int      Id          { get; set; }
        public string   Description { get; set; } 
        public bool     State       { get; set; }  
    }
}
