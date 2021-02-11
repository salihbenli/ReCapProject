using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            {
                new Car {CarId=1,BrandId=1, ColorId="3abs459",DailyPrice=150,Description="Ford Focus",ModelYear="2012"},
                new Car {CarId=2,BrandId=2, ColorId="3abs789",DailyPrice=200,Description="Renault Megan",ModelYear="2011"},
                new Car {CarId=3,BrandId=3, ColorId="3abs741",DailyPrice=250,Description="Renault Twingo",ModelYear="1999"},
                new Car {CarId=4,BrandId=4, ColorId="3abs852",DailyPrice=300,Description="Bmw i320",ModelYear="2005"},
                new Car {CarId=5,BrandId=5, ColorId="3abs369",DailyPrice=350,Description="Audi Q3",ModelYear="2020"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p=>p.CarId==car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
           return _cars.Where(p=>p.CarId==Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
