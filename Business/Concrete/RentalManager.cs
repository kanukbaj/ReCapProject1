﻿using Business.Abstract;
using Core.Utilities.Results;
using Core.Results.Concreate;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public  class RentalManager : IRentalService
    {
        IRentalDal rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            rentalDal = _rentalDal;
        }
        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate==null)
            {
                return new ErrorResult();
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult();
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccesDataResult<List<Rental>>(_rentalDal.GetAll());
        }
    }
}
