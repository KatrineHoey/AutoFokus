
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoFokus.Service.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AutoFokus.Service.Domain
{
    public interface ICarService
    {
        IEnumerable<Car> GetCars();
        Car GetCar(int id);
        void CreateCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int id);
    }

    public class CarService : ICarService
    {
        private readonly CarContext _context;
        public CarService(CarContext context)
        {
            _context = context;
        }

        public IEnumerable<Car> GetCars()
        {
            return _context.Cars.ToList();
        }

        public Car GetCar(int id)
        {
            return _context.Cars.Find(id);


        }


        public void CreateCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }


        public void UpdateCar(Car car)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; //Hvis der trackes, så sker der fejl.
            if(_context.Cars.Any(c => c.ID == car.ID)) //Tjekker at bilen stadig findes i databasen. 
            {
                car.RowVersion = car.RowVersion + 1; //Viser at der er blevet foretaget en ændring ved denne bil. 
                _context.Cars.Update(car);
                _context.SaveChanges();
            }


        }

        public void DeleteCar(int id)
        {
            if(_context.Cars.Any(c => c.ID == id))
            {
                _context.Cars.Remove(_context.Cars.Find(id));
                _context.SaveChanges();
            }
            
        }


    }
}
