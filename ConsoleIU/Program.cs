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
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + " " + car.ModelYear + " yılına ait günlük fiyatı " + car.DailyPrice + " TL");
            }
        }
    }
}
