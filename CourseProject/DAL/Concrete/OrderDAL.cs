using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
   public class OrderDAL : IOrderDAL
    {
        private string connectionString;

        public OrderDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public void DeleteOrder(int OrderID)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Order where OrderID = @OrderID";
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

                comm.CommandText = $"select * from [Order] where OrderID={OrderID}";
                //comm.Parameters.Clear();
                //comm.Parameters.AddWithValue("@OrderID", OrderID);
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

        public OrderDTO UpdateOrder(OrderDTO order)
        {
            throw new NotImplementedException();
        }


        public List<OrderDTO> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public List<OrderDTO> GetAllOrdersSorted(int n)
        {
            throw new NotImplementedException();
        }

        public OrderDTO PackOrder(OrderDTO order)
        {
            throw new NotImplementedException();
        }

    }
}
