using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspBilCrud.Models
{
    public class CarViewModel
    {
        public int ID { get; set; }
        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string Billede { get; set; }

        public int RowVersion { get; set; }
    }
}
