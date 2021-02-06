using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("Marka bilgisi başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Başarısız. Marka bilgisi en az 2 harften oluşmalıdır.");
            }
            
            
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("Marka bilgisi başarıyla kaldırıldı.");
        }

 
        public void Update(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Update(brand);
                Console.WriteLine("Marka bilgisi başarıyla güncellendi.");
            }
            else
            {
                Console.WriteLine("Başarısız. Marka bilgisi en az 2 harften oluşmalıdır.");
            }
        }

        List<Brand> IBrandService.GetAll()
        {
            return _brandDal.GetAll();
        }

        List<Brand> IBrandService.GetCarsByBrandId(int BrandId)
        {
            return _brandDal.GetAll(p => p.BrandId == BrandId);
        }
    }
}
