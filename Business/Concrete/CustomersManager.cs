using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer cutomers)
        {
            _cutomersDal.Add(cutomers);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customer cutomers)
        {
            _cutomersDal.Delete(cutomers);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_cutomersDal.GetAll());

        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_cutomersDal.Get(p => p.CustomerId == id));
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer cutomers)
        {
            _cutomersDal.Update(cutomers);
            return new SuccessResult(Messages.Updated);
        }
    }
}
