using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car
                {
                    Id = 1,
                    BrandId = 1,
                    ColorId = 1,
                    ModelYear = "2012",
                    DailyPrice = 150000,
                    Description = "Otomatik Benzinli",
                },
                new Car
                {
                    Id = 2,
                    BrandId = 2,
                    ColorId = 2,
                    ModelYear = "2011",
                    DailyPrice = 100000,
                    Description = "Manuel Dizel"
                },
                 new Car
                {
                    Id = 3,
                    BrandId = 2,
                    ColorId = 2,
                    ModelYear = "2013",
                    DailyPrice = 240000,
                    Description = "Manuel Dizel"
                },
                  new Car
                {
                    Id = 4,
                    BrandId = 2,
                    ColorId = 2,
                    ModelYear = "2020",
                    DailyPrice = 340000,
                    Description = "Manuel Dizel"
                }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
