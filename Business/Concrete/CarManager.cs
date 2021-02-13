using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Insert(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            
            return new ErrorResult(Messages.DailyPriceInvalid);
           
            

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessResult<List<Car>>(_carDal.GetAll(),Messages.ListGenerated);
        }
       

        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            
            return new ErrorResult(Messages.DailyPriceInvalid);
            
        }

      

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.ListGenerated);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessResult<Car>(_carDal.Get(c => c.Id == id),Messages.InfoGenerated);
        }
    }
}
