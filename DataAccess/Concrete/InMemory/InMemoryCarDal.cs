using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1, ModelYear=2017, DailyPrice=409000, Description="Mercedes C 200"},
                new Car{Id = 2, BrandId = 2, ColorId = 1, ModelYear = 2016, DailyPrice = 129500, Description = "FIAT EGEA" },
                new Car{Id = 3, BrandId = 3, ColorId = 2, ModelYear = 2016, DailyPrice = 145500, Description = "RENAULT FLUENCE" },
                new Car{Id = 4, BrandId = 4, ColorId = 2, ModelYear = 2013, DailyPrice = 161500, Description = "VOLKSWAGEN GOLF" },
                new Car{Id = 5, BrandId = 5, ColorId = 2, ModelYear = 2015, DailyPrice = 473500, Description = "VOLVO XC 60" },
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
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

        public List<Car> GetAllByBrandId(int BrandId)
        {
            return _cars.Where(c => c.BrandId ==BrandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
