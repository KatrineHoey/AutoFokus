using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspBilCrud.Database;
using AspApiCars.Database;
using AutofokusContracts.DTOs;

namespace AspApiCars.Controllers
{
    [Route("api/v{version:apiVersion}/Cars")]
    // Which versions the controller responds to
    [ApiVersion("1")]
    [ApiVersion("2")]

    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarContext _context;

        public CarsController(CarContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        [MapToApiVersion("1")]
        public IEnumerable<CarDto> GetCars()
        {
            return _context.Cars.Select(c => Mapper.Map(c));
        }

        // GET: api/Cars
        [HttpGet]
        [MapToApiVersion("2")]
        public IEnumerable<CarDto> GetCarsV2()
        {
            return _context.Cars.Select(c => Mapper.Map(c));
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public CarDto GetCar(int id)
        {
            return Mapper.Map(_context.Cars.Find(id));
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public void PutCar(int id, [FromBody]CarDto car)
        {
            _context.Cars.Update(Mapper.Map(car));
            _context.SaveChanges();

        }

        // POST: api/Cars
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public void PostCar([FromBody] CarDto car)
        {
            _context.Cars.Add(Mapper.Map(car));
            _context.SaveChanges();

        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public void DeleteCar(int id)
        {
            _context.Cars.Remove(_context.Cars.Find(id));
            _context.SaveChanges();
        }

    }


}

//[ApiVersion("2")]
//[Route("api/v{v:apiVersion}/Cars")]
//[ApiController]
//public class CarsV2Controller : ControllerBase
//{
//    private readonly CarContext _context;

//    public CarsV2Controller(CarContext context)
//    {
//        _context = context;
//    }

//    // GET: api/Cars
//    [HttpGet]
//    public IEnumerable<CarDto> GetCars()
//    {
//        return _context.Cars.Select(c => Mapper.Map(c));
//    }

//    // GET: api/Cars/5
//    [HttpGet("{id}")]
//    public CarDto GetCar(int id)
//    {
//        return Mapper.Map(_context.Cars.Find(id));
//    }
//}
