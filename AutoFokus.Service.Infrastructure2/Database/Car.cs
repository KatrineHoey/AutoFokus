using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoFokus.Service.Infrastructure
{
    public class Car
    {
        public int ID { get; set; }
        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string Billede { get; set; }

        public int RowVersion { get; set; }
    }
}
