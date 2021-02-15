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
    public class CustomersManager : ICustomersService
    {
        ICustomersDal _cutomersDal;
        public CustomersManager(ICustomersDal cutomersDal)
        {
            _cutomersDal = cutomersDal;
        }
        public IResult Add(Customers cutomers)
        {
            _cutomersDal.Add(cutomers);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customers cutomers)
        {
            _cutomersDal.Delete(cutomers);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customers>> GetAll()
        {
            return new SuccessDataResult<List<Customers>>(_cutomersDal.GetAll());

        }

        public IDataResult<Customers> GetById(int id)
        {
            return new SuccessDataResult<Customers>(_cutomersDal.Get(p => p.UsersMId == id));
        }

        public IResult Update(Customers cutomers)
        {
            _cutomersDal.Update(cutomers);
            return new SuccessResult(Messages.Updated);
        }
    }
}
