using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DAL.Interfaces;
using DTO;

namespace BusinessLogic.Solid
{
    public class Customer:ICustomer
    {
        private readonly ICustomerDAL _customerDAL;
        


        public Customer(ICustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }

        public CustomerDTO AddCustomer(CustomerDTO customer)
        {

            customer = new CustomerDTO
            {
            
                EMail = Console.ReadLine(),
                Addres = Console.ReadLine(),
                Phone = Console.ReadLine(),
                Description= Console.ReadLine()
            };



            return _customerDAL.CreateCustomer(customer);
        }


        public void RemoveCustomer(int CustomerID)
        {
            
            _customerDAL.DeleteCustomer(CustomerID);
        }

        public CustomerDTO GetCustomer(int CustomerID)
        {
            return _customerDAL.GetCustomerById(CustomerID);
        }

        public void ShowCustomers()
        {
            Console.WriteLine("CustomerID\tEMail\tAddress\tPhone\tDescription");
            foreach (var customer in _customerDAL.GetAllCustomers())
            {
                Console.WriteLine($"{customer.CustomerID}\t{customer.EMail}\t{customer.Addres}\t{customer.Phone}\t{customer.Description}");

            }
        }


        public CustomerDTO ChangeCustomer(CustomerDTO customer)
        {
         
            return _customerDAL.UpdateCustomer(customer);
        }
    }
}
