using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarDetailsByBrand(string brandName);

        List<CarDetailDto> GetCarDetailsByColor(string colorName);
        List<CarDetailDto> GetCarDetailsById(int carId);
    }
}
