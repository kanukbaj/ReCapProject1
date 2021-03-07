using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class UserManager : IUserService
    {
        IUserDal userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("New User Added");
        }

        public IDataResult<List<User>> GetAllById(int Id)
        {
            return new SuccesDataResult<List<User>>(_userDal.GetAll(u => u.UserId == Id));
        }
    }
}
