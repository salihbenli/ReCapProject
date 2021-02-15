using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfUsersDal : EfEntityRepositoryBase<Users, NortwindContext>, IUsersDal
    {
    }
}
