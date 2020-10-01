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
    public class ItemTests
        {


       

        [Test]
        public void AddItemTest()
        {
            ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            Item result = new Item(dal);
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
            ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            Item result = new Item(dal);

            Assert.IsTrue(result.GetItem(33).ItemID==33, "Cannot find the item");
        }


        [Test]
        public void UpdateItemTest()
        {
            ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            Item result = new Item(dal);
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
            ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            Item result = new Item(dal);
            result.RemoveItem(33);
            Assert.IsTrue(result.GetItem(33).ItemID!= 33, "Item was not deleted");
        }
    }
}
