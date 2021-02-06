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
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("----------Tüm arabaların listesi----------\n");
            
                foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " model " + car.Description + "  araç : Günlük sadece " + car.DailyPrice + "TL");
            }


            Console.WriteLine("\n----------Listeye yeni araba ekleme----------\n");
            carManager.Add(new Entities.Concrete.Car { Id = 6, BrandId = 4, ColorId = 2, DailyPrice = 125, Description = "Manuel", ModelYear = 2017 });
            carManager.Add(new Entities.Concrete.Car { Id = 7, BrandId = 3, ColorId = 1, DailyPrice = 0, Description = "Sedan", ModelYear = 2019 });



            Console.WriteLine("\n----------Listeye yeni marka ekleme----------\n");
            brandManager.Add(new Entities.Concrete.Brand { BrandId = 4, BrandName = "Volkswagen" });
            brandManager.Add(new Entities.Concrete.Brand { BrandId = 5, BrandName = "Z" });


            Console.WriteLine("\n----------Markaya göre filtreleme----------\n");
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\n----------Renge göre filtreleme----------\n");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.ModelYear);
            }

        }
    }
}
