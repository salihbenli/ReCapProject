using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _rentalsDal;
        public RentalsManager(IRentalsDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rentals)
        {
            if (rentals.ReturnDate == null && _rentalsDal.GetRentalDetails(I => I.CarId == rentals.CarId).Count > 0)
            {
                return new ErrorResult("hata");
            }
            _rentalsDal.Add(rentals);
            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(Rental rentals)
        {
            _rentalsDal.Delete(rentals);
            return new SuccessResult(Messages.Deleted);
        }
        public IDataResult<List<RentalsDetailDto>> GetRentalByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalsDetailDto>>(_rentalsDal.GetRentalDetails(c => c.CarId == carId));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalsDal.GetAll());

        }
        public IDataResult<List<RentalsDetailDto>> GetRentalByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<RentalsDetailDto>>(_rentalsDal.GetRentalDetails(cu => cu.CustomerId == customerId));
        }
       
        public IDataResult<List<RentalsDetailDto>> GetRentalByRentDate(DateTime rentDate)
        {
            return new SuccessDataResult<List<RentalsDetailDto>>(_rentalsDal.GetRentalDetails(r => r.RentDate == rentDate));
        }

        public IDataResult<List<RentalsDetailDto>> GetRentalByReturnDate(DateTime returnDate)
        {
            return new SuccessDataResult<List<RentalsDetailDto>>(_rentalsDal.GetRentalDetails(r => r.ReturnDate == returnDate));
        }


        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalsDal.Get(p => p.RentalId == id));
        }
        public IDataResult<List<RentalsDetailDto>> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentalsDetailDto>>(_rentalsDal.GetRentalDetails(filter),"geri döndü");
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rentals)
        {
            _rentalsDal.Update(rentals);
            return new SuccessResult(Messages.Updated);
        }
    }
}
