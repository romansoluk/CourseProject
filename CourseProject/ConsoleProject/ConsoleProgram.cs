using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace ConsoleProject
{
    public class ConsoleProgram
    {

        private string connectionString;

        public ConsoleProgram(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public bool SignUp()
        {
            return true;
        }

        public bool Login()
        {

            Console.WriteLine("Login to continue:\n");
            Console.WriteLine("Login: ");
            string login= Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            ShipperDTO shipper = new ShipperDTO();

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                //ShipperDTO shipper = new ShipperDTO();

                comm.CommandText = $"select * from Shipper where Login= '{login}'";


                 PasswordActions decrypt=new PasswordActions();
              
                 SqlDataReader reader = comm.ExecuteReader();
                 while(reader.Read())
                {
                    shipper.Login = reader["Login"].ToString();
                    shipper.Password = (byte[])reader["Password"];
                    if(shipper.Login!=login || decrypt.PasswordDecryption(shipper.Password)!=password)
                    {
                        return false;
                    }
                }

            }

            return true;
        }

    }
}
