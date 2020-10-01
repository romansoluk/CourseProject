using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrderDAL
    {
        OrderDTO CreateOrder(OrderDTO order);
        OrderDTO GetOrderById(int OrderID);
        List<OrderDTO> GetAllOrders();
        void DeleteOrder(int OrderID);
        List<OrderDTO> GetAllOrdersSorted(int n);
        OrderDTO PackOrder(int OrderID);
    

    }
}
