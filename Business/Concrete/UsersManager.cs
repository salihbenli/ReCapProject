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
        public IResult Add(Users users)
        {
            _usersDal.Add(users);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Users users)
        {
            _usersDal.Delete(users);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Users>> GetAll()
        {
            return new SuccessDataResult<List<Users>>(_usersDal.GetAll());

        }

        public IDataResult<Users> GetById(int id)
        {
            return new SuccessDataResult<Users>(_usersDal.Get(p => p.UsersId == id));

        }

        public IResult Update(Users users)
        {
            _usersDal.Update(users);
            return new SuccessResult(Messages.Updated);
        }
    }
}
