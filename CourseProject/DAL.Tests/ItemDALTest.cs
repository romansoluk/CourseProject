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
    public class ItemDALTest
    {
     
            

           [Test]
            public void CreateItemTest()
            {
                ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
                var result = dal.CreateItem(new ItemDTO
                {
                    Name = "Test Item",
                    Price = 200.00,
                    OnStock = 1
                });
                Assert.IsTrue(result.ItemID >= 0, "returned ID should be more than zero");
             
            }
            

            [Test]
            public void GetItemByIDTest()
            {
                ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
                var result = dal.GetItemById(1);
                Assert.IsTrue(result.ItemID == 1, "returned ID does not match request");
                
            }

            [Test]
            public void DeleteItemTest()
            {
                ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
                dal.DeleteItem(12);

              Assert.IsTrue(dal.GetItemById(12).ItemID!=12, "item still in db"); ;
            
            }


            [Test]
        public void GetAllItemsTest()
        {
            ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            var result = dal.GetAllItems();

            Assert.IsTrue(result.Count!=0, "no items shown"); ;
           
        }

        [Test]
        public void UpdateItem()
        {
            ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);

            ItemDTO upd = dal.UpdateItem(new ItemDTO
            {
                ItemID = 7,
                Price = 10,
                OnStock = 1
            });
          
          

            Assert.IsTrue(upd.Price==10, "Item was not updated");

        }



    }
}

