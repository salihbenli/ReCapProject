using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalsService
    {
        IResult Add(Rental rentals);
        IResult Update(Rental rentals);
        IResult Delete(Rental rentals);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int id);
        IDataResult<List<RentalsDetailDto>> GetRentalByCarId(int carId);
        IDataResult<List<RentalsDetailDto>> GetRentalByCustomerId(int customerId);
        IDataResult<List<RentalsDetailDto>> GetRentalByRentDate(DateTime rentDate);
        IDataResult<List<RentalsDetailDto>> GetRentalByReturnDate(DateTime returnDate);
        IDataResult<List<RentalsDetailDto>> GetRentalDetails(Expression<Func<Rental, bool>> filter = null);
    }
}
