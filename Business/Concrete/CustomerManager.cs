﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public  class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult("New Customer Added");
        }
        public IDataResult<List<Customer>> GetAllByCustomerId(int Id)
        {
            (_customerDal.GetAll(c=>c.CustomerId == Id));
        }

        IResult ICustomerService.Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<Customer>> ICustomerService.GetAllByCustomerId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
