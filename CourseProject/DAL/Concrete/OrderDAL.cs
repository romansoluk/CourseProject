using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace DAL.Concrete
{
   public class OrderDAL : IOrderDAL
    {
        private string connectionString;

        public OrderDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public OrderDTO CreateOrder(OrderDTO order)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into [Order] (CustomerIDKEY, ShipperIDKEY, Price, Date, Comment) output INSERTED.OrderID values (@CustomerIDKEY, @ShipperIDKEY, @Price, @Date, @Comment)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@CustomerIDKEY", order.CustomerIDKEY);
                comm.Parameters.AddWithValue("@ShipperIDKEY", order.ShipperIDKEY);
                comm.Parameters.AddWithValue("@Price", order.Price);
                comm.Parameters.AddWithValue("@Date", order.Date);
                comm.Parameters.AddWithValue("@Comment", order.Comment);
                conn.Open();

                order.OrderID = Convert.ToInt32(comm.ExecuteScalar());
                return order;
            }
        }

        public void DeleteOrder(int OrderID)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from AddToOrder where OrderIDKEY=@OrderID delete from [Order] where OrderID = @OrderID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@OrderID", OrderID);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }



        public OrderDTO GetOrderById(int OrderID)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                OrderDTO order = new OrderDTO();

                comm.CommandText = "select * from [Order] where OrderID=@OrderID";
               
                comm.Parameters.AddWithValue("@OrderID", OrderID);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    order = new OrderDTO
                    {
                        OrderID = Convert.ToInt32(reader["OrderID"]),
                        ShipperIDKEY = Convert.ToInt32(reader["ShipperIDKEY"]),
                        CustomerIDKEY = Convert.ToInt32(reader["CustomerIDKEY"]),
                        Price = Convert.ToDouble(reader["Price"]),
                        Date = Convert.ToDateTime(reader["Date"]),
                        Comment = reader["Comment"].ToString()
                    };
                }

                return order;
            }
        }



        public List<OrderDTO> GetAllOrders()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Order";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<OrderDTO> orders = new List<OrderDTO>();
                while (reader.Read())
                {

                    orders.Add(new OrderDTO
                    {
                        OrderID = Convert.ToInt32(reader["OrderID"]),
                        CustomerIDKEY = Convert.ToInt32(reader["CustomerIDKEY"]),
                        ShipperIDKEY = Convert.ToInt32(reader["ShipperIDKEY"]),
                        Price = Convert.ToDouble(reader["Price"]),
                        Date=Convert.ToDateTime(reader["Date"]),
                        Comment=reader["Comment"].ToString()
                    });
                }

                return orders;
            }
        }

        public List<OrderDTO> GetAllOrdersSorted(int SortParameter)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {



                if (SortParameter == 1)
                {
                    comm.CommandText = "select * from Order order by Date ASC";
                }
                if (SortParameter == 2)
                {
                    comm.CommandText = "select * from Order order by Date DESC";

                }
                if (SortParameter == 3)
                { comm.CommandText = "select * from Order order by Price DESC"; }

                else
                { comm.CommandText = "select * from Item"; }





                
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<OrderDTO> orders = new List<OrderDTO>();
                while (reader.Read())
                {

                    orders.Add(new OrderDTO
                    {
                        OrderID = Convert.ToInt32(reader["OrderID"]),
                        CustomerIDKEY = Convert.ToInt32(reader["CustomerIDKEY"]),
                        ShipperIDKEY = Convert.ToInt32(reader["ShipperIDKEY"]),
                        Price = Convert.ToDouble(reader["Price"]),
                        Date = Convert.ToDateTime(reader["Date"]),
                        Comment = reader["Comment"].ToString()
                    });
                }

                return orders;
            }
        }

        //Update Order: Completes Order and marks it as COMPLETED
        public OrderDTO PackOrder(int OrderID) 
        {

            double price = 0;
            int stock = 0;
            AddToOrderDTO orderitem = new AddToOrderDTO();
            ItemDTO item = new ItemDTO();
            OrderDTO order = new OrderDTO();

            ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            OrderDAL dal1 = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from AddToOrder where OrderIDKEY=@OrderIDKEY";
                comm.Parameters.AddWithValue("@OrderIDKey", OrderID);
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                List<AddToOrderDTO> orderitems = new List<AddToOrderDTO>();
                while (reader.Read())
                {
                    orderitems.Add(new AddToOrderDTO
                    {
                        OrderIDKEY = Convert.ToInt32(reader["OrderIDKEY"]),
                        ItemIDKEY = Convert.ToInt32(reader["ItemIDKEY"]),
                        Amount = Convert.ToInt32(reader["Amount"]),
                    });
                }


                for (int i = 0; i < orderitems.Count; i++)
                {
                    if (orderitems[i].Amount > dal.GetItemById(orderitems[i].ItemIDKEY).OnStock)
                    {
                        break;
                    }
                    else
                    {
                        stock = dal.GetItemById(orderitems[i].ItemIDKEY).OnStock - orderitems[i].Amount;
                        price = dal1.GetOrderById(orderitems[i].OrderIDKEY).Price + orderitems[i].Amount * dal.GetItemById(orderitems[i].ItemIDKEY).Price;
                        item = new ItemDTO
                        {
                            ItemID = dal.GetItemById(orderitems[i].ItemIDKEY).ItemID,
                            Name = dal.GetItemById(orderitems[i].ItemIDKEY).Name,
                            Price = dal.GetItemById(orderitems[i].ItemIDKEY).Price,
                            OnStock = stock
                        };
                        dal.UpdateItem(item);
                    }

                }

             
            }



             OrderDAL dal2 = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);

            order = new OrderDTO
            {
                OrderID=OrderID,
                Price = price,
                Comment="Completed"
            };



                using (SqlConnection conn1 = new SqlConnection(this.connectionString))
                using (SqlCommand comm1 = conn1.CreateCommand())
                {
                    comm1.CommandText = "update [Order] set Price= @Price, Comment=@Comment where OrderID = @OrderID";
                    comm1.Parameters.Clear();
                    comm1.Parameters.AddWithValue("@OrderID", order.OrderID);
                    comm1.Parameters.AddWithValue("@Price", order.Price);
                    comm1.Parameters.AddWithValue("@Comment", order.Comment);
                    conn1.Open();

                    order.OrderID = Convert.ToInt32(comm1.ExecuteScalar());


                }
           
                
                    return order;

            

           
        }

    }
}
