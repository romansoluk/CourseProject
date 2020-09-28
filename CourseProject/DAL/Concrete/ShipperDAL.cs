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
    public class ShipperDAL:IShipperDAL
    {
        private string connectionString;

        public ShipperDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public ShipperDTO GetShipperById(int ShipperID)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                ShipperDTO shipper = new ShipperDTO();

                comm.CommandText = $"select * from Shipper where ShipperID={ShipperID}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    shipper = new ShipperDTO
                    {
                        ShipperID = Convert.ToInt32(reader["ShipperID"]),
                        Login = reader["Login"].ToString(),
                        Password =(byte[])(reader["Password"]),
                        //Password = System.Text.Encoding.Default.GetString(reader["Password"]),
                        EMail = reader["EMail"].ToString(),
                        Addres = reader["Adress"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Description = reader["Description"].ToString(),
                    };
                }
                
                return shipper;
            }
        }


        public void Login()
        {
            throw new NotImplementedException();
        }


        public ShipperDTO GetShipper(ShipperDTO shipper)
        {
            throw new NotImplementedException();
        }


        public ShipperDTO CreateShipper(ShipperDTO shipper)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Shipper (Login, Password, EMail, Adress, Phone, Description) output INSERTED.ShipperID values (@Login, @Password, @EMail, @Adress, @Phone, @Description)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Login", shipper.Login);
                comm.Parameters.AddWithValue("@Password", shipper.Password);
                comm.Parameters.AddWithValue("@EMail", shipper.EMail);
                comm.Parameters.AddWithValue("@Adress", shipper.Addres);
                comm.Parameters.AddWithValue("@Phone", shipper.Phone);
                comm.Parameters.AddWithValue("@Description", shipper.Description);
                conn.Open();

                shipper.ShipperID = Convert.ToInt32(comm.ExecuteScalar());
                return shipper;
            }
        }

    }
}
