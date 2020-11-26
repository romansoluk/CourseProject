using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICustomer
    {
        CustomerDTO AddCustomer(CustomerDTO customer); //Sign up as Customer
        CustomerDTO ChangeCustomer(CustomerDTO customer);
        void RemoveCustomer(int CustomerID);
        CustomerDTO GetCustomer(int CustomerID);
        CustomerDTO GetCustomerByLogin(string CustomerLogin);
        bool Log(string Email, string Phone);


        AddToOrderDTO AddPosition(AddToOrderDTO addtoorder);
        void DeletePosition(int OrderIDKEY);
        List<AddToOrderDTO> SameOrderPositions(int OrderIDKEY);

        List<ItemDTO> ShowItems();
        ItemDTO GetItem(int ItemID);

        OrderDTO AddOrder(OrderDTO order);
    }
}
