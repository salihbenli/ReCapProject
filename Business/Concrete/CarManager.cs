﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice>0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Lütfen günlük fiyat kısmını 0'dan büyük giriniz. Girdiğiniz değer :"+car.DailyPrice);
            }
        }

        public void Delete(Car car)
        {
            try
            {
                _carDal.Delete(car);
                Console.WriteLine("Araba başarıyla silindi.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Girdiğiniz Id değerine sahip araba yok!");
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetAllByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        }

        public Car GetById(int id)
        {
            return _carDal.Get(p => p.CarId == id);
        }

        public List<Car> GetByModelYear(string year)
        {
            return _carDal.GetAll(c => c.ModelYear.Contains(year) == true);
        }

        public List<CarDetailDto> GetCarDetail()
        {
            return _carDal.GetCarDetail();
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                Console.WriteLine("Araba başarıyla güncellendi.");
            }
            else
            {
                Console.WriteLine("Lütfen günlük fiyat kısmını 0'dan büyük giriniz. Girdiğiniz değer : "+car.DailyPrice);
            }
        }
    }
}
