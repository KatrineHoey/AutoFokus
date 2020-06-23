using Autofokus.Service.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspBilCrud.Models
{
    public class Mapper
    {
        public static CarViewModel Map(CarDto dto)
        {
            return new CarViewModel { ID = dto.ID, Model = dto.Model, Brand = dto.Brand, Color = dto.Color, Billede = dto.Billede, RowVersion = dto.RowVersion }; 
        }

        public static IEnumerable<CarViewModel> Map(IEnumerable<CarDto> dtos)
        {
            return dtos.Select(x => Map(x)).AsEnumerable(); //
        }

        public static CarDto Map(CarViewModel view)
        {
            return new CarDto
            { ID = view.ID, Model = view.Model, Brand = view.Brand, Color = view.Color, Billede = view.Billede, RowVersion  =view.RowVersion };
        }
    }
}
