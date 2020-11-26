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
    public class UserTests
        {


     
        [Test]
        public void AddItemTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            User result = new User(shipperDAL,itemDAL, customerDAL, orderDAL, addtoorderDAL);
            var item = new ItemDTO
            {
                Name = "BL Test",
                Price = 100,
                OnStock = 2
            };



            var r=result.AddItem(item);
            Assert.IsTrue(r.ItemID != 0, "returned ID should be more than zero");
        }


        [Test]
        public void GetItemTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            User result = new User(shipperDAL, itemDAL, customerDAL, orderDAL, addtoorderDAL);

            Assert.IsTrue(result.GetItem(4).ItemID==4, "Cannot find the item");
        }


        [Test]
        public void UpdateItemTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            User result = new User(shipperDAL, itemDAL, customerDAL, orderDAL, addtoorderDAL);
            var item = new ItemDTO
            {
                ItemID = 32,
                Price = 25,
                OnStock = 20
            };
            Assert.IsTrue(result.ChangeItem(item).Price == 25, "Item was not updated");


        }


        [Test]
        public void DeleteItemTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            User result = new User(shipperDAL, itemDAL, customerDAL, orderDAL, addtoorderDAL);
            result.RemoveItem(33);
            Assert.IsTrue(result.GetItem(33).ItemID != 33, "Item was not deleted");
        }


        [Test]
        public void LogTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            User result = new User(shipperDAL, itemDAL, customerDAL, orderDAL, addtoorderDAL);
            result.Log("TestShipper", "1234");
            Assert.IsTrue(result.Log("TestShipper", "1234")==true, "User was not logged");
        }

        [Test]
        public void AddShipperTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            User result = new User(shipperDAL, itemDAL, customerDAL, orderDAL, addtoorderDAL);
            
                 var shipper = new ShipperDTO
                 {
                     Login = "TestShipper2",
                     Password = new ConsoleProject.PasswordActions().PasswordEncryption("1234"),
                     EMail = "Test2",
                     Addres = "Test2",
                     Phone = "Test2",
                     Description = "Test2"
                 };

            shipper = result.AddShipper(shipper);
            Assert.IsTrue(shipper.ShipperID >= 0, "returned ID should be more than zero");
            
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
        public void GetShipperTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            User result = new User(shipperDAL, itemDAL, customerDAL, orderDAL, addtoorderDAL);
            result.GetShipper(2);
            Assert.IsTrue(result.GetShipper(2).ShipperID == 2, "Shipper was not found");
        }


        [Test]
        public void CompleteOrderTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            User result = new User(shipperDAL, itemDAL, customerDAL, orderDAL, addtoorderDAL);
            result.CompleteOrder(2);
            Assert.IsTrue(result.CompleteOrder(2).Comment=="Completed", "Order was not comleted");
        }


        [Test]
        public void DeleteOrderTest()
        {
            ItemDAL itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ShipperDAL shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            CustomerDAL customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            OrderDAL orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            AddToOrderDAL addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            User result = new User(shipperDAL, itemDAL, customerDAL, orderDAL, addtoorderDAL);
            result.DeleteOrder(1);
            Assert.IsTrue(result.GetOrder(1).OrderID != 1, "Order was not deleted");
        }
    }
}
