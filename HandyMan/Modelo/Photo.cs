using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Photo
    {
        public int      Id        { get; set; }
        public string   ImagePath { get; set; } // Ruta de la imagen
       
        // CONSTRUCTOR
        public Photo(string imagePath)
        {
            ImagePath = imagePath;
        }
    }
}
