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

        // CONSTRUCTOR
        public Payment (string description, bool state)
        {
            Description = description;
            State       = state;
        }
        public Payment (int id, string description, bool state)
        {
            Id = id;
            Description = description;
            State = state;
        }
    }
}
