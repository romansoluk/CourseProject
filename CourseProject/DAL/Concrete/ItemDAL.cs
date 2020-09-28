using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class ItemDAL : IItemDAL
    {
        private string connectionString;

        public ItemDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ItemDTO CreateItem(ItemDTO item)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Item (Name, Price, OnStock) output INSERTED.ItemID values (@Name, @Price, @OnStock)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Name", item.Name);
                comm.Parameters.AddWithValue("@Price", item.Price);
                comm.Parameters.AddWithValue("@OnStock", item.OnStock);
                conn.Open();

                item.ItemID = Convert.ToInt32(comm.ExecuteScalar());
                return item;
            }
        }

        public void DeleteItem(int ItemID)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Item where ItemID = @ItemID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ItemID", ItemID);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public List<ItemDTO> GetAllItems()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Item";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<ItemDTO> items = new List<ItemDTO>();
                while (reader.Read())
                {

                    items.Add(new ItemDTO
                    {
                        ItemID = Convert.ToInt32(reader["ItemID"]),
                        Name = reader["Name"].ToString(),
                        Price = Convert.ToDouble(reader["Price"]),
                        OnStock = Convert.ToInt32(reader["OnStock"])
                    });
                }

                return items;
            }
        }

        public List<ItemDTO> GetAllItemsSorted(int SortParameter)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {



                if (SortParameter == 1)
                {
                    comm.CommandText = "select * from Item order by Price ASC";
                }
                if (SortParameter == 2)
                {
                    comm.CommandText = "select * from Item order by Name DESC";

                }
                if (SortParameter == 3)
                { comm.CommandText = "select * from Item order by ItemID DESC"; }

                else
                { comm.CommandText = "select * from Item"; }





                //comm.CommandText = "order by [Name] ASC";

                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<ItemDTO> items = new List<ItemDTO>();
                while (reader.Read())
                {

                    items.Add(new ItemDTO
                    {
                        ItemID = Convert.ToInt32(reader["ItemID"]),
                        //Name = reader["Name"].ToString(),
                        Name = (reader["Name"]).ToString(),
                        Price = Convert.ToDouble(reader["Price"]),
                        OnStock = Convert.ToInt32(reader["OnStock"])
                    });
                }
                //Convert.
                return items;
            }
        }




        public ItemDTO GetItemById(int ItemID)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                ItemDTO items = new ItemDTO();

                comm.CommandText = $"select * from Item where ItemID={ItemID}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    items = new ItemDTO
                    {
                        ItemID = Convert.ToInt32(reader["ItemID"]),
                        Name = reader["Name"].ToString(),
                        Price = Convert.ToDouble(reader["Price"]),
                        OnStock = Convert.ToInt32(reader["OnStock"])
                    };
                }

                return items;
            }
        }

        public ItemDTO UpdateItem(ItemDTO item)
        {
           
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update Item set Price= @Price, OnStock=@OnStock where ItemID = @ItemID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@ItemID", item.ItemID);
                //comm.Parameters.AddWithValue("@Name", item.Name);
                comm.Parameters.AddWithValue("@Price", item.Price);
                comm.Parameters.AddWithValue("@OnStock", item.OnStock);
                conn.Open();
             
                item.ItemID = Convert.ToInt32(comm.ExecuteScalar());


                return item;
            }




        }

    }
}

