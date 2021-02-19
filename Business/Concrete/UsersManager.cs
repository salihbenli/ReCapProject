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
    public class UsersManager : IUsersService
    {
        IUsersDal _usersDal;
        public UsersManager(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }
        public IResult Add(User users)
        {
            _usersDal.Add(users);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User users)
        {
            _usersDal.Delete(users);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_usersDal.GetAll());

        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_usersDal.Get(p => p.UserId == id));

        }

        public IResult Update(User users)
        {
            _usersDal.Update(users);
            return new SuccessResult(Messages.Updated);
        }
    }
}
