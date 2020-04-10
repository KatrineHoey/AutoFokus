using AutofokusContracts.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutofokusContracts.Services
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetCarsAsync();
        Task<CarDto> GetCarAsync(int id);
        Task AddAsync(CarDto car);
        Task UpdateAsync(int id, CarDto car);
        Task RemoveAsync(int id);
    }
}
