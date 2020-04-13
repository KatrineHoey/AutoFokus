
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspBilCrud.Database
{
    public class DbInitializer
    {
        public static void Initialize(CarContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Cars.Any())
            {
                return;   // DB has been seeded
            }

            var cars = new Car[]
            {
                new Car{Brand="Ford", Model="Fiesta", Color="Sort", RowVersion = 1 },
                new Car{Brand="Ford", Model="Galaxy", Color="Grøn", RowVersion = 1},
                new Car{Brand="Citroen", Model="C1", Color="Grå", RowVersion = 1},
            };

            foreach (Car car in cars)
            {
                context.Cars.Add(car);
            }
            context.SaveChanges();


        }
    }
}
