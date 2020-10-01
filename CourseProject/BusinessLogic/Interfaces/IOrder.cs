using BusinessLogic.Solid;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    interface IOrder
    {
        OrderDTO AddOrder(OrderDTO order);
        OrderDTO GetOrder(int OrderID);
        OrderDTO CompleteOrder(int OrderID);
        void DeleteOrder(int OrderID);
        void ShowOrders(int ShipperIDKEY);
        void ShowOrdersSorted(int SortParameter, int ShipperIDKEY);
    }
}
