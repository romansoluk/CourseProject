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

        public List<CustomerDTO> GetAllCustomers(CustomerDTO customer)
        {
            throw new NotImplementedException();
        }


        public CustomerDTO GetCustomerById(int CustomerID)
        {
            throw new NotImplementedException();
        }


       
        public CustomerDTO GetCustomersWithOrders()
        {
            throw new NotImplementedException();
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


    }
}
