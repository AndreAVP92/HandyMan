using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Permission
    {
        public int      Id          { get; set; }
        public int      Module      { get; set; }
        public string   Description { get; set; }

        // CONSTRUCTOR
        public Permission(int module, string description)
        {
            Module      = module;
            Description = description;
        }
    }
}
