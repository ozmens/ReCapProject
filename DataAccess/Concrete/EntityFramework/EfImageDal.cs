using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfImageDal: EfEntityRepositoryBase<Image, CarsDbContext>, IImageDal
    {
        public List<ImageDetailDto> GetCarDetails()
        {
            using (CarsDbContext context = new CarsDbContext())
            {
                var result = from i in context.CarImages
                             join c in context.Cars
                             on i.CarId equals c.Id

                             select new ImageDetailDto
                             {
                                 CarId=c.Id,
                                 CarName=c.CarName,
                                 ImageId=i.Id,
                                 ImagePath=i.ImagePath
                             };
                return result.ToList();
            }
        }
    }
}
