using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspBilCrud.Database
{
    public class Car
    {
        public int ID { get; set; }
        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string Billede { get; set; }
    }
}
