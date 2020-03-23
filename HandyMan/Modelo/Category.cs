using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Category
    {
        public int          Id                  { get; set; }
        public string       Description         { get; set; }
        public bool         State               { get; set; }
        public List<SubCategory> SubCategories  { get; set; }

        // CONSTRUCTORES
        public Category (string description, bool state, List<SubCategory> subCategories)
        {
            Description     = description;
            State           = state;
            SubCategories   = subCategories;
        }

        public Category (string description)
        {
            Description = description;
            State       = true;
        }
    }
}
