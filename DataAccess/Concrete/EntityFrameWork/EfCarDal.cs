using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NortwindContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (NortwindContext context=new NortwindContext())
            {
                var result = from c in context.Cars
                             join b in context.Brand
                             on c.BrandId equals b.Id
                             join cl in context.Color
                             on c.ColorId equals cl.Id
                             select new CarDetailDto
                             {
                                 CarId=c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 ModelYear=c.ModelYear,
                                 Description=c.Description,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
