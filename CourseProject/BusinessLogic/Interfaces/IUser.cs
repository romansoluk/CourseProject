using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUser
    {
     

        ItemDTO AddItem(ItemDTO item);
        ItemDTO ChangeItem(ItemDTO item);
        void ShowItemsSorted(int SortingParameter);
        List<ItemDTO> ShowItems();
        void RemoveItem(int ItemID);
        ItemDTO GetItem(int ItemID);


        bool Log(string login, string password);
        ShipperDTO AddShipper(ShipperDTO shipper); //as Sign Up for Shipper(User)
        ShipperDTO ChangeShipper(ShipperDTO shipper);
        void RemoveShipper(int ShipperID);
        ShipperDTO GetShipper(int ShipperID);
        ShipperDTO GetShipperByLogin(string ShipperLogin);


        OrderDTO GetOrder(int OrderID);
        OrderDTO CompleteOrder(int OrderID);
        void DeleteOrder(int OrderID);
        List<OrderDTO> ShowOrders(int ShipperIDKEY);

        void ShowCustomers(); 
     



    }
}
