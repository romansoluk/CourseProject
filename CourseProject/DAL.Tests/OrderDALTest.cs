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
    public class OrderDALTest
    {
     
            

           [Test]
            public void CreateOrderTest()
            {
            OrderDAL dal = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);

            DateTime date = DateTime.Now.Date;

            
            var result = new OrderDTO
            {
                
                CustomerIDKEY = 1,
                ShipperIDKEY = 8,
                Date = date,
                Comment = "Test"
            };

            result = dal.CreateOrder(result);
            Assert.IsTrue(result.OrderID >= 0, "returned ID should be more than zero");
             
            }
            

            [Test]
            public void GetOrderByIDTest()
            {
            OrderDAL dal = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
                var result = dal.GetOrderById(7);
                Assert.IsTrue(result.OrderID == 7, "returned ID does not match request");
                
            }

            [Test]
            public void DeleteOrderTest()
            {
            OrderDAL dal = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
                dal.DeleteOrder(7);

              Assert.IsTrue(dal.GetOrderById(7).OrderID != 7, "item still in db"); ;
            
            }


           

        [Test]
        public void UpdateOrderTest()
        {
            OrderDAL dal = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);

          
          
           var result = dal.PackOrder(7);

            Assert.IsTrue(result.Price>0, "Order was not updated");

        }



    }
}

