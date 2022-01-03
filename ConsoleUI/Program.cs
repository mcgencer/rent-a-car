 using Business.Concrete;
using DateAccess.Concrete.EntityFramwork;
using DateAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
   
    class Program
    {
        static void Main(string[] args)
        {
           CarTest();
            // BrandTest();
            // ColorTest();
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
          //  AddTest(carManager,brandManager, colorManager);
           // UpdateTest(carManager, brandManager, colorManager);
           // DeleteTest(carManager, brandManager, colorManager);
        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)

                {
                    Console.WriteLine("Brand Id = " + car.BrandId + "  |  "
                        + "Color Id = " + car.ColorId + "  |  "
                        + "Model Year = " + car.ModelYear + "  |  "
                        + "Description = " + car.Description + "  --->  "
                        + "Daily Price = " + car.DailyPrice + " TL");
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
            Console.WriteLine("-----------Günlük Araç Kiralama Fiyatları-----------");
            Console.WriteLine("*********************************************");
            foreach (var car in carManager.GetAll().Data)

            {
                Console.WriteLine("Brand Id = " + car.BrandId + "  |  "
                    + "Color Id = " + car.ColorId + "  |  "
                    + "Model Year = " + car.ModelYear + "  |  "
                    + "Description = " + car.Description + "  --->  "
                    + "Daily Price = " + car.DailyPrice + " TL");
            }
            Console.WriteLine(" Araçlarımız çok konforlu ve en dolu paketlerdir");
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("------Marka ıd ve Marka Adı------");
            Console.WriteLine("------------------------------------------------");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("Brand Id = " + brand.BrandId + "  |  " + "Brand Name = " + brand.BrandName);
            }
            Console.WriteLine(" ");
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("------Renk Id  Ve Renk Adı------");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("Color Id = " + color.ColorId + "  |  " + "Color Name = " + color.ColorName);
            }
            Console.WriteLine(" ");
        }

        private static void AddTest(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("-------------Yerleştirme Testi--------------");
            carManager.Add(new Car { BrandId = 2, ColorId = 3, ModelYear = "2015", DailyPrice = 500, Description = "AUDI A4 B8" });
            brandManager.Add(new Brand { BrandName = "AUDI" });
            colorManager.Add(new Color { ColorName = "Gray" });
        }
        private static void UpdateTest(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("------------Güncelleme Testi---------");
            carManager.Update(new Car { CarId = 2002, BrandId = 2, ColorId = 1003, ModelYear = "2016", DailyPrice = 550, Description = "AUDI A4 B8" });
            brandManager.Update(new Brand { BrandId = 1003, BrandName = "AUDI" });
            colorManager.Update(new Color { ColorId = 1003, ColorName = "Blue" });
        }
        private static void DeleteTest(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("------------ Silme Testi---------");
            carManager.Delete(new Car { CarId = 2004, BrandId = 2003, ColorId = 2003, ModelYear = "2005", DailyPrice = 250, Description = "TOYOTA COROLLA" });
            brandManager.Delete(new Brand { BrandId = 2003, BrandName = "TOYOTA" });
            colorManager.Delete(new Color { ColorId = 2003, ColorName = "Yellow" });
        }
           
    }
} 