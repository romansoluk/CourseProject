using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DAL.Concrete;
using DAL.Interfaces;
using DTO;

namespace BusinessLogic.Solid
{
    public class User : IUser
    {
        private readonly IShipperDAL _shipperDAL;
        private readonly IItemDAL _itemDAL;
        private readonly ICustomerDAL _customerDAL;
        private readonly IOrderDAL _orderDAL;
        private readonly IAddToOrderDAL _addtoorderDAL;



        public User(IShipperDAL shipperDAL, IItemDAL itemDAL, ICustomerDAL customerDAL, IOrderDAL orderDAL, IAddToOrderDAL addtoorderDAL)
        {
            _shipperDAL = shipperDAL;
            _itemDAL = itemDAL;
            _customerDAL = customerDAL;
            _orderDAL = orderDAL;
            _addtoorderDAL = addtoorderDAL;
        }

       

        public ShipperDTO AddShipper(ShipperDTO shipper)
        {

          return _shipperDAL.CreateShipper(shipper);
         }


        public void RemoveShipper(int ShipperID)
        {
         
            _shipperDAL.DeleteShipper(ShipperID);
        }

        public ShipperDTO GetShipper(int ShipperID)
        {
            return _shipperDAL.GetShipperById(ShipperID);
        }

        public ShipperDTO GetShipperByLogin(string ShipperLogin)
        {
            return _shipperDAL.GetShipperByLogin(ShipperLogin);
        }


       

        public ShipperDTO ChangeShipper(ShipperDTO shipper)
        {

            return _shipperDAL.UpdateShipper(shipper);
        }


        public bool Log(string Login, string password)
        {
            return _shipperDAL.Login(password, Login);
        }



        public ItemDTO AddItem(ItemDTO item)
        {

            return _itemDAL.CreateItem(item);
        }


        public void RemoveItem(int ItemID)
        {

            _itemDAL.DeleteItem(ItemID);
           
        }

        public ItemDTO GetItem(int ItemID)
        {
            return _itemDAL.GetItemById(ItemID);
        }

        public List<ItemDTO> ShowItems()
        {
            return _itemDAL.GetAllItems();
        }

        public void ShowItemsSorted(int SortParameter)
        {

            _itemDAL.GetAllItemsSorted(SortParameter);
        }

        public ItemDTO ChangeItem(ItemDTO item)
        {

            return _itemDAL.UpdateItem(item);
        }


        public void DeleteOrder(int OrderID)
        {

            _orderDAL.DeleteOrder(OrderID);
            
        }

        public OrderDTO GetOrder(int OrderID)
        {

            return _orderDAL.GetOrderById(OrderID);
        }

        public OrderDTO CompleteOrder(int OrderID)
        {
            return _orderDAL.PackOrder(OrderID);
        }


        public List<OrderDTO> ShowOrders(int ShipperIDKEY)
        {
            return _orderDAL.GetAllOrders(ShipperIDKEY);
        }


        public void ShowCustomers()
        {
            _customerDAL.GetAllCustomers();

        }
    }
}
