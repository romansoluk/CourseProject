using DAL.Concrete;
using DTO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Solid;


namespace BusinessLogic.Tests
{
    
    [TestFixture]
    [Transaction(TransactionOption.RequiresNew), ComVisible(true)]
    public class CustomerTests
        {


     
        [Test]
        public void AddOrderTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            Customer result = new Customer(customerDAL, addtoorderDAL, itemDAL, orderDAL);
            var order = new OrderDTO
            {
                ShipperIDKEY = 2,
                CustomerIDKEY=2,
                Price=0.00,
                Date=DateTime.Now,
                Comment="No info"


            };



            var r=result.AddOrder(order);
            Assert.IsTrue(r.OrderID != 0, "returned ID should be more than zero");
        }


        [Test]
        public void GetCustomerTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            Customer result = new Customer(customerDAL, addtoorderDAL, itemDAL, orderDAL);
            Assert.IsTrue(result.GetCustomer(2).CustomerID==2, "Cannot find the customer");
        }


        [Test]
        public void UpdateCustomerTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            Customer result = new Customer(customerDAL, addtoorderDAL, itemDAL, orderDAL);
            var customer = new CustomerDTO
            {
              EMail="EmailTest",
              CustomerID=2,
              Phone="TestPhone",
              Addres="TestAddress",
              Description="TestDescription"

            };
            Assert.IsTrue(result.ChangeCustomer(customer).EMail == "EmailTest", "Customer was not updated");


        }


        [Test]
        public void DeleteCustomerTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            Customer result = new Customer(customerDAL, addtoorderDAL, itemDAL, orderDAL);
            result.RemoveCustomer(3);
            Assert.IsTrue(result.GetCustomer(3).CustomerID != 3, "Customer was not deleted");
        }


        [Test]
        public void LogTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            Customer result = new Customer(customerDAL, addtoorderDAL, itemDAL, orderDAL);
            result.Log("Test2","Test2");
            Assert.IsTrue(result.Log("Test2", "Test2") ==true, "Customer was not logged");
        }

        [Test]
        public void AddCustomerTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            Customer result = new Customer(customerDAL, addtoorderDAL, itemDAL, orderDAL);

            var customer = new CustomerDTO
                 {
                     
                     EMail = "Test2",
                     Addres = "Test2",
                     Phone = "Test2",
                     Description = "Test2"
                 };

         result.AddCustomer(customer);
            Assert.IsTrue(customer.CustomerID >= 0, "returned ID should be more than zero");
            
        }

        public void DeleteShipperTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            User result = new User(shipperDAL, itemDAL, customerDAL, orderDAL, addtoorderDAL);
            result.RemoveShipper(4);
            Assert.IsTrue(result.GetShipper(4).ShipperID !=4, "Shipper was not deleted");
        }

        [Test]
        public void GetItemTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            Customer result = new Customer(customerDAL, addtoorderDAL, itemDAL, orderDAL);
            result.GetItem(1);
            Assert.IsTrue(result.GetItem(1).ItemID == 1, "Item was not found");
        }


        [Test]
        public void DeletePositionTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            Customer result = new Customer(customerDAL, addtoorderDAL, itemDAL, orderDAL);
            result.DeletePosition(1);
            Assert.IsTrue(result.SameOrderPositions(1).Count == 0, "Position was not deleted");
        }
    }
}
