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
    public class ShipperDALTest
    {
     
            

           [Test]
            public void CreateShipperTest()
            {
                ShipperDAL dal = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
                PasswordActions password = new PasswordActions();


            
            var result = new ShipperDTO
            {
                Login = "TestShipper",
                Password = password.PasswordEncryption("1234"),
                EMail = "Test",
                Addres = "Test",
                Phone = "Test",
                Description = "Test"
            };

            result = dal.CreateShipper(result);
            Assert.IsTrue(result.ShipperID >= 0, "returned ID should be more than zero");
             
            }
        
       
            

            [Test]
            public void GetShipperByIDTest()
            {
                ShipperDAL dal = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
                var result = dal.GetShipperById(13);
                Assert.IsTrue(result.ShipperID == 13, "returned ID does not match request");
                
            }

            [Test]
            public void DeleteShipperTest()
            {
                ShipperDAL dal = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
                dal.DeleteShipper(13);

              Assert.IsTrue(dal.GetShipperById(13).ShipperID!=13, "item still in db"); ;
            
            }


           

        [Test]
        public void UpdateShipperTest()
        {
            ShipperDAL dal = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            var shupper = dal.GetShipperById(13);
            ShipperDTO upd = new ShipperDTO
            {
                ShipperID = 13,
                EMail="Updated",
                Addres="Updated",
                Phone="Updated",
                Description="Updated"
            };
          
           var result = dal.UpdateShipper(upd);

            Assert.IsTrue(result.EMail=="Updated", "Shipper was not updated");

        }



    }
}

