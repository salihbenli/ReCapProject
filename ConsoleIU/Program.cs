using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using System;

namespace ConsoleIU
{
    class Program
    {
        static void Main(string[] args)
        {
            //EfCarDal();
            CarDetail();
        }

        private static void CarDetail()
        {
            Console.WriteLine("Car Color"+ "\t" +"Car Model" + "\t" + "Brand" + "\t\t" + "Description" + "\t" + "DailyPrice");
            CarManager carManager2 = new CarManager(new EfCarDal());
            foreach (var car2 in carManager2.GetCarDetail())
            {
                Console.WriteLine(car2.ColorName + "\t" + car2.ModelYear + "\t" + car2.BrandName + "\t" + car2.Description + "\t" + car2.DailyPrice);
            }
        }

        private static void EfCarDal()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + " " + car.ModelYear + " yılına ait günlük fiyatı " + car.DailyPrice + " TL");
            }
        }
    }
}
