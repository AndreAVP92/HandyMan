using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Address
    {
        public int      Id        { get; set; }
        public string   Street    { get; set; }
        public int      Number    { get; set; }
        public int      Zip       { get; set; }
        public string   Province  { get; set; }
        public string   Locality  { get; set; }

        // CONSTRUCTOR
        public Address (string street, int number, int zip, string province, string locality)
        {
            Street      = street;
            Number      = number;
            Zip         = zip;
            Province    = province;
            Locality    = locality;
        }
    }
}
