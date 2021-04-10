using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1,ColorId=1,ModelYear=2020,DailyPrice=120,Description="Sedan"},
                new Car{Id=2, BrandId=2,ColorId=2,ModelYear=2019,DailyPrice=110,Description="Hatchback"},
                new Car{Id=3, BrandId=2,ColorId=1,ModelYear=2017,DailyPrice=100,Description="Otomatik"},
                new Car{Id=4, BrandId=3,ColorId=3,ModelYear=2018,DailyPrice=130,Description="Sedan"},
                new Car{Id=5, BrandId=3,ColorId=2,ModelYear=2019,DailyPrice=140,Description="Spor"},

            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete= _cars.SingleOrDefault(c=>c.Id==car.Id);
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

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c=>c.Id==Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByBrand(string brandName)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByColor(string colorName)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsById(int carId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
