using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Solid
{
    class Order
    {
        private readonly IOrderDAL _orderDAL;
      


        public Order(IOrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
        }

        public OrderDTO AddOrder(OrderDTO order)
        {
            
            DateTime date=new DateTime();
            Console.WriteLine("Enter NEW ORDER DETAILS (CUSTOMER ID, SHIPPER ID, DESCRIPTION");
            Console.WriteLine("CustomerID, ShipperID, Description ");
            order = new OrderDTO
            {
            
                CustomerIDKEY = Convert.ToInt32(Console.ReadLine()),
                ShipperIDKEY = Convert.ToInt32(Console.ReadLine()),
                Price = 0,
                Date = date.Date,
                Comment = Console.ReadLine()
            };

            return _orderDAL.CreateOrder(order);
        }


        public void RemoveOrder(int OrderID)
        {
            Console.WriteLine("ENTER ORDER ID TO DELETE:");
            OrderDTO order = new OrderDTO();
            order.OrderID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Deleting order ID: {order.OrderID}");
            _orderDAL.DeleteOrder(order.OrderID);
        }

        public OrderDTO GetOrder(int OrderID)
        {
            Console.WriteLine("ENTER ORDER ID TO SHOW");
            OrderID = Convert.ToInt32(Console.ReadLine());
            return _orderDAL.GetOrderById(OrderID);
        }

        public OrderDTO ChangeOrder(int OrderID)
        {
            Console.WriteLine("ENTER ORDER ID TO COMPLETE:");
            return _orderDAL.PackOrder(OrderID);
        }
    }
}
