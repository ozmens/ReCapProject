using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

        IDataResult<List<Car>> GetAll();

        IDataResult<Car> GetById(int id);

        IDataResult<List<CarDetailDto>> GetCarDetails();

        IResult AddTransactionalTest(Car car);

        IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(string brandName);

        IDataResult<List<CarDetailDto>> GetCarDetailsByColor(string colorName);
        IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId);
    }
}
