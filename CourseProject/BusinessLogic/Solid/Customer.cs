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
        private readonly IAddToOrderDAL _addtoorderDAL;
        private readonly IItemDAL _itemDAL;
        private readonly IOrderDAL _orderDAL;



        public Customer(ICustomerDAL customerDAL, IAddToOrderDAL addtoorderDAL, IItemDAL itemDAL, IOrderDAL orderDAL)
        {
            _customerDAL = customerDAL;
            _addtoorderDAL = addtoorderDAL;
            _itemDAL = itemDAL;
            _orderDAL = orderDAL;

        }



        public CustomerDTO AddCustomer(CustomerDTO customer)
        {

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

        public CustomerDTO GetCustomerByLogin(string CustomerLogin)
        {
            return _customerDAL.GetCustomerByLogin(CustomerLogin);
        }

        public void ShowCustomers()
        {
            _customerDAL.GetAllCustomers();
           
        }

        public List<ItemDTO> ShowItems()
        {
           return _itemDAL.GetAllItems();
        }

        public CustomerDTO ChangeCustomer(CustomerDTO customer)
        {
         
            return _customerDAL.UpdateCustomer(customer);
        }


        public AddToOrderDTO AddPosition(AddToOrderDTO addtoorder)
        {
            return _addtoorderDAL.CreateAddToOrder(addtoorder);
        }


        public void DeletePosition(int OrderIDKEY)
        {
            _addtoorderDAL.DeleteAddToOrder(OrderIDKEY);
        }


        public List<AddToOrderDTO> SameOrderPositions(int OrderIDKEY)
        {
            return _addtoorderDAL.FromSameOrder(OrderIDKEY);
        }


        public ItemDTO GetItem(int ItemID)
        {
            return _itemDAL.GetItemById(ItemID);
        }

     

        public OrderDTO AddOrder(OrderDTO order)
        {

            return _orderDAL.CreateOrder(order);
        }

        public bool Log(string Email, string Phone)
        {
            return _customerDAL.Login(Email, Phone);
        }
    }
}
