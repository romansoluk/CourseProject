using ConsoleProject;
using DAL.Concrete;
using DTO;
using Microsoft.IdentityModel.Protocols;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;



namespace DAL.Tests
{
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    public class CustomerDALTest
    {
     
            

           [Test]
            public void CreateCustomerTest()
            {
            CustomerDAL dal = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
                


            
            var result = new CustomerDTO
            {
                
                EMail = "Test",
                Addres = "Test",
                Phone = "Test",
                Description = "Test"
            };

            result = dal.CreateCustomer(result);
            Assert.IsTrue(result.CustomerID >= 0, "returned ID should be more than zero");
             
            }
            

            [Test]
            public void GetCustomerByIDTest()
            {
            CustomerDAL dal = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
                var result = dal.GetCustomerById(3);
                Assert.IsTrue(result.CustomerID == 3, "returned ID does not match request");
                //Assert.IsNull()
            }

            [Test]
            public void DeleteCustomerTest()
            {
            CustomerDAL dal = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
                dal.DeleteCustomer(3);

              Assert.IsTrue(dal.GetCustomerById(3).CustomerID != 3, "item still in db"); ;
            
            }


           

        [Test]
        public void UpdateCustomerTest()
        {
            CustomerDAL dal = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            
            CustomerDTO upd = new CustomerDTO
            {
                CustomerID = 3,
                EMail="Updated",
                Addres="Updated",
                Phone="Updated",
                Description="Updated"
            };
          
           var result = dal.UpdateCustomer(upd);

            Assert.IsTrue(result.EMail=="Updated", "Customer was not updated");

        }



    }
}

