//using AspBilCrud.Database;
using AutofokusContracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFokus.Service.Infrastructure;

namespace AspApiCars.Models
{
    public class Mapper
    {
        public static Car Map(CarDto dto)
        {
            return new Car { ID = dto.ID, Model = dto.Model, Billede = dto.Billede, Brand = dto.Brand, Color = dto.Color, RowVersion = dto.RowVersion };
        }

        public static IEnumerable<CarDto> Map(IEnumerable<Car> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static CarDto Map(Car model)
        {
            return new CarDto { ID = model.ID, Model = model.Model, Billede = model.Billede, Brand = model.Brand, Color = model.Color, RowVersion = model.RowVersion};
        }
    }
}
