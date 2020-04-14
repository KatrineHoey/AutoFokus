
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoFokus.Service.Infrastructure;

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
            _context.Cars.Update(car);
            _context.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            _context.Cars.Remove(_context.Cars.Find(id));
            _context.SaveChanges();
        }


    }
}
