using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araba veritabanına başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Araba veritabanına eklenemedi. Günlük fiyat 0'dan büyük olmalıdır.");
            }
                
              
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int BrandId)
        {
            return _carDal.GetAll(p => p.BrandId == BrandId);
        }

        public List<Car> GetCarsByColorId(int ColorId)
        {
            return _carDal.GetAll(p => p.ColorId == ColorId);
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                Console.WriteLine("Araba veritabanında başarıyla güncellendi.");
            }
            else
            {
                Console.WriteLine("Araba veritabanında güncellenemedi. Günlük fiyat 0'dan büyük olmalıdır.");
            }
        }
    }
}
