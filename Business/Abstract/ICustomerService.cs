﻿using System;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
 public  interface ICustomerService
    {
        IResult Add(Customer customer);
        IDataResult<List<Customer>> GetAllByCustomerId(int Id);

    }
}
