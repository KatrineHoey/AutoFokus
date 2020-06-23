using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Autofokus.Service.Contracts.DTOs
{
    public class CarDto
    {
        public int ID { get; set; }
        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string Billede { get; set; }

        public int RowVersion { get; set; }

    }
}
