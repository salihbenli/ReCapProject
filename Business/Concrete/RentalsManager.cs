using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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
        public IResult Add(Rentals rentals)
        {
            _rentalsDal.Add(rentals);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Rentals rentals)
        {
            _rentalsDal.Delete(rentals);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentalsDal.GetAll());

        }

        public IDataResult<Rentals> GetById(int id)
        {
            return new SuccessDataResult<Rentals>(_rentalsDal.Get(p => p.RentId == id));
        }

        public IResult Update(Rentals rentals)
        {
            _rentalsDal.Update(rentals);
            return new SuccessResult(Messages.Updated);
        }
    }
}
