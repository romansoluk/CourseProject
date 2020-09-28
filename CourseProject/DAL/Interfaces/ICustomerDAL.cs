using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICustomerDAL
    {
        List<CustomerDTO> GetAllCustomers(CustomerDTO customer);
        CustomerDTO GetCustomerById(int CustomerID);
        CustomerDTO GetCustomersWithOrders();
        CustomerDTO CreateCustomer(CustomerDTO customer);

    }
}
