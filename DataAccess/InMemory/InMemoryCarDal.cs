using DateAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DateAccess.Concrete.InMemory
{
   public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId = 1, BrandId = 1,ColorId = 2,ModelYear = "2020",DailyPrice = 500, Description = "Otomatik"},
                new Car{CarId = 2, BrandId = 1,ColorId = 5,ModelYear = "2019",DailyPrice = 250, Description = "Otomatik"},
                new Car{CarId = 3, BrandId = 2,ColorId = 3,ModelYear = "2018",DailyPrice = 1000, Description = "Otomatik"},
                new Car{CarId = 4, BrandId = 4,ColorId = 6,ModelYear = "2019",DailyPrice = 750, Description = "Otomatik"},
                new Car{CarId = 5, BrandId = 3,ColorId = 8,ModelYear = "2021",DailyPrice = 1000, Description = "Otomatik"},
                new Car{CarId=6,BrandId=5,ColorId=9,ModelYear="2022",DailyPrice=2500,Description="Manuel"},
                new Car{CarId=7,BrandId=5,ColorId=9,ModelYear="2022",DailyPrice=2500,Description="Manuel"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
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

        public List<Car> GetById(int CarId)
        {
            return _cars.Where(c => c.CarId == CarId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.ColorId = car.CarId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
