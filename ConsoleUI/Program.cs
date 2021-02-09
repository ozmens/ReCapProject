using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName + "/" + car.DailyPrice);
            }

            carManager.Insert(new Entities.Concrete.Car { BrandId = 4, ColorId = 2, CarName = "V", DailyPrice = 125, Description = "Manuel", ModelYear = 2017 });
            carManager.Update(new Entities.Concrete.Car { Id= 1, BrandId = 3, ColorId = 1, CarName = "Y", DailyPrice = 0, Description = "Sedan", ModelYear = 2019 });
            

            carManager.GetById(2);

            Console.WriteLine("-----------İşlemler sonrası liste-----------");

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            }

            BrandManager brandManager = new BrandManager(new EfBrandDal());

          
            brandManager.Insert(new Entities.Concrete.Brand { BrandName = "Volkswagen" });
            brandManager.Insert(new Entities.Concrete.Brand { BrandName = "Z" });
            brandManager.Update(new Entities.Concrete.Brand { BrandId = 5, BrandName = "Alfa Romeo" });
            
            brandManager.GetByBrandId(3);

            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Insert(new Entities.Concrete.Color { ColorName = "Kırmızı" });
            colorManager.Update(new Entities.Concrete.Color { ColorId = 3, ColorName = "Sarı" });
            

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + "/" + color.ColorName);
            }

            colorManager.GetByColorId(4);
        }
    }
}
