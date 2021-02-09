using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        void Insert(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);
        List<Brand> GetAll();

        Brand GetByBrandId(int brandId);

    }
}
