﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICustomerDAL
    {
        void DeleteCustomer(int CustomerID);
        List<CustomerDTO> GetAllCustomers();
        CustomerDTO GetCustomerById(int CustomerID);
        CustomerDTO GetCustomerByLogin(string CustomerLogin);
        CustomerDTO CreateCustomer(CustomerDTO customer);
        CustomerDTO UpdateCustomer(CustomerDTO customer);
        bool Login(string password, string Login);
    }
}
