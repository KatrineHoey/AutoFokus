using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApiCars.Models;
using Autofokus.Service.Contracts.DTOs;
using AutoFokus.Service.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspApiCars.Controllers
{
    [Produces("application/json")]
    [Route("api/Cars")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/Cars
        [HttpGet]
        public IEnumerable<CarDto> GetCars()
        {
            return _carService.GetCars().Select(a => Mapper.Map(a));
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public CarDto GetCar(int id)
        {
            if (_carService.GetCar(id) == null)
            {
                CarDto carDTO = null;
                return carDTO;
            }
            else
            {
                return Mapper.Map(_carService.GetCar(id));
            }

        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public void PutCar(int id, [FromBody]CarDto car)
        {
            _carService.UpdateCar(Mapper.Map(car));

        }

        // POST: api/Cars
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public void PostCar([FromBody] CarDto car)
        {
            car.RowVersion = 1;
            _carService.CreateCar(Mapper.Map(car));

        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public void DeleteCar(int id)
        {
            _carService.DeleteCar(id);
        }
    }
}


