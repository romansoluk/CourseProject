using ConsoleProject;
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
    public class CustomerDAL:ICustomerDAL
    {
        private string connectionString;

        public CustomerDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<CustomerDTO> GetAllCustomers()
        {
            throw new NotImplementedException();
        }


        public CustomerDTO GetCustomerById(int CustomerID)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                CustomerDTO customer = new CustomerDTO();

                comm.CommandText = $"select * from Customer where CustomerID=@CustomerID";
                comm.Parameters.AddWithValue("@CustomerID", CustomerID);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    customer = new CustomerDTO
                    {
                        CustomerID = Convert.ToInt32(reader["CustomerID"]),
                        EMail = reader["EMail"].ToString(),
                        Addres = reader["Adress"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Description = reader["Description"].ToString(),
                    };
                }

                return customer;
            }
        }


        public CustomerDTO GetCustomerByLogin(string EMail)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                CustomerDTO customer = new CustomerDTO();

                comm.CommandText = $"select * from Customer where EMail=@EMail";
                comm.Parameters.AddWithValue("@EMail", EMail);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    customer = new CustomerDTO
                    {
                        CustomerID = Convert.ToInt32(reader["CustomerID"]),
                        EMail = reader["EMail"].ToString(),
                        Addres = reader["Adress"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Description = reader["Description"].ToString(),
                    };
                }

                return customer;
            }
        }

        public void DeleteCustomer(int CustomerID)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Customer where CustomerID = @CustomerID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@CustomerID", CustomerID);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }
       
        public CustomerDTO UpdateCustomer(CustomerDTO customer)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update Customer set EMail= @EMail, Adress=@Adress, Phone=@Phone, Description=@Description where CustomerID = @CustomerID";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                comm.Parameters.AddWithValue("@EMail", customer.EMail);
                comm.Parameters.AddWithValue("@Adress", customer.Addres);
                comm.Parameters.AddWithValue("@Phone", customer.Phone);
                comm.Parameters.AddWithValue("@Description", customer.Description);
                conn.Open();

                customer.CustomerID = Convert.ToInt32(comm.ExecuteScalar());


                return customer;
            }
        }


        public CustomerDTO CreateCustomer(CustomerDTO customer)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Customer (EMail, Adress, Phone, Description) output INSERTED.CustomerID values ( @EMail, @Adress, @Phone, @Description)";
                comm.Parameters.Clear();
                
                comm.Parameters.AddWithValue("@EMail", customer.EMail);
                comm.Parameters.AddWithValue("@Adress", customer.Addres);
                comm.Parameters.AddWithValue("@Phone", customer.Phone);
                comm.Parameters.AddWithValue("@Description", customer.Description);
                conn.Open();

                customer.CustomerID = Convert.ToInt32(comm.ExecuteScalar());
                return customer;
            }
        }


        public bool Login(string Password, string Login)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                CustomerDTO shipper = new CustomerDTO();

                comm.CommandText = $"select * from Customer where Email=@Login";
                comm.Parameters.AddWithValue("@Login", Login);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    shipper = new CustomerDTO
                    {
                        CustomerID = Convert.ToInt32(reader["CustomerID"]),
                        EMail = reader["EMail"].ToString(),
                        Addres = reader["Adress"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Description = reader["Description"].ToString(),
                    };
                    if (shipper.Phone == Password)
                    {
                        return true;
                    }
                }


            }
            return false;
        }

    }
}
