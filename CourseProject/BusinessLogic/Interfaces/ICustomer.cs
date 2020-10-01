using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    interface ICustomer
    {
        CustomerDTO AddCustomer(CustomerDTO customer);
        CustomerDTO ChangeCustomer(CustomerDTO customer);
        //void ShowCustomerSorted(int SortingParameter);
        void ShowCustomers();
        void RemoveCustomer(int CustomerID);
        CustomerDTO GetCustomer(int CustomerID);
    }
}
