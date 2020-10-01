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
    public class AddToOrderDAL : IAddToOrderDAL
    {
        private string connectionString;

        public AddToOrderDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public AddToOrderDTO AddToOrder(AddToOrderDTO addtoorder )
        {
            throw new NotImplementedException();
        }


        //adds one order position to order
        public AddToOrderDTO CreateAddToOrder(AddToOrderDTO addtoorder)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into AddToOrder (OrderIDKEY, ItemIDKEY, Amount) values (@OrderIDKEY, @ItemIDKEY, @OAmount)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@OrderIDKEY", addtoorder.OrderIDKEY);
                comm.Parameters.AddWithValue("@ItemIDKEY", addtoorder.ItemIDKEY);
                comm.Parameters.AddWithValue("@Amount", addtoorder.Amount);
                conn.Open();

                return addtoorder;
            }
        }

        //deletes one position from order
        public void DeleteAddToOrder(int OrderIDKEY)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from AddToOrder where OrderIDKEY = @OrderIDKEY";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@OrderIDKEY", OrderIDKEY);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        //shows all positions from one(same) order
        public List<AddToOrderDTO> FromSameOrder(int OrderIDKEY)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from AddToOrder where OrderIDKEY = @OrderIDKEY";
                comm.Parameters.AddWithValue("@OrderIDKEY", OrderIDKEY);
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<AddToOrderDTO> items = new List<AddToOrderDTO>();
                while (reader.Read())
                {

                    items.Add(new AddToOrderDTO
                    {
                        OrderIDKEY = Convert.ToInt32(reader["OrderIDKEY"]),
                        ItemIDKEY = Convert.ToInt32(reader["ItemIDKEY"]),
                        Amount = Convert.ToInt32(reader["Amount"])
                    });
                }

                return items;
            }
        }

    }
}
