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
    [Produces("application/json")]
    [Route("api/Cars")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CarsController : ControllerBase
    {
        private readonly CarContext _context;

        public CarsController(CarContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public IEnumerable<CarDto> GetCars()
        {
            return _context.Cars.Select(c => Mapper.Map(c));
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public CarDto GetCar(int? id)
        {
            if (_context.Cars.Any(c => c.ID == id.Value))
            {
                return Mapper.Map(_context.Cars.Find(id.Value));
            }
            else
            {
                CarDto car = null;
                return car;
            }

        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public void PutCar(int id, [FromBody]CarDto car)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; //Hvis der trackes, så sker der fejl.

            if (_context.Cars.Any(c => c.ID == car.ID)) //Tjekker at bilen stadig findes i databasen. 
            {
                car.RowVersion = car.RowVersion + 1; //Viser at der er blevet foretaget en ændring ved denne bil. 
                _context.Cars.Update(Mapper.Map(car));
                _context.SaveChanges();

            }

        }

        // POST: api/Cars
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public void PostCar([FromBody] CarDto car)
        {
            car.RowVersion = 1;
            _context.Cars.Add(Mapper.Map(car));
            _context.SaveChanges();

        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public void DeleteCar(int? id)
        {
            if (_context.Cars.Any(c => c.ID == id.Value)) //Tjekker at bilen stadig findes i databasen. 
            {
                _context.Cars.Remove(_context.Cars.Find(id.Value)); //Fjerner bilen fra databasen. 
                _context.SaveChanges();
            }
        }
    }

    [Route("api/Cars")]
    [ApiController]
    [ApiVersion("2.0")]
    public class CarsController2 : ControllerBase
    {
        private readonly CarContext _context;

        public CarsController2(CarContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public IEnumerable<CarDto> GetCars()
        {
            return _context.Cars.Select(c => Mapper.Map(c));
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public CarDto GetCar(int? id)
        {
            if (_context.Cars.Any(c => c.ID == id.Value))
            {
                return Mapper.Map(_context.Cars.Find(id.Value));
            }
            else
            {
                CarDto car = null;
                return car;
            }

        }
        // PUT: api/Cars/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public void PutCar(int id, [FromBody]CarDto car)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; //Hvis der trackes, så sker der fejl.

            if (_context.Cars.Any(c => c.ID == car.ID)) //Tjekker at bilen stadig findes i databasen. 
            {
                car.RowVersion = car.RowVersion + 1; //Viser at der er blevet foretaget en ændring ved denne bil. 
                _context.Cars.Update(Mapper.Map(car));
                _context.SaveChanges();

            }

        }

        // POST: api/Cars
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public void PostCar([FromBody] CarDto car)
        {
            car.RowVersion = 1;
            _context.Cars.Add(Mapper.Map(car));
            _context.SaveChanges();

        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public void DeleteCar(int? id)
        {
            if (_context.Cars.Any(c => c.ID == id.Value)) //Tjekker at bilen stadig findes i databasen. 
            {
                _context.Cars.Remove(_context.Cars.Find(id.Value)); //Fjerner bilen fra databasen. 
                _context.SaveChanges();
            }
        }
    }
}


