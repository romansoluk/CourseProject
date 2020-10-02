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
    public class AddToOrderDALTest
    {
     
            

           [Test]
            public void CreateAddToOrderTest()
            {
            AddToOrderDAL dal = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);

           

            
            var result = new AddToOrderDTO
            {
                
               OrderIDKEY=5,
               ItemIDKEY=1,
               Amount=28
            };

            result = dal.CreateAddToOrder(result);
            Assert.IsTrue(result.OrderIDKEY == 5 && result.ItemIDKEY==1, "AddToOrder was not created");
             
            }

       
        [Test]
        public void GetAllFromSameOrderTest()
        {
            AddToOrderDAL dal = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            var result = dal.FromSameOrder(6);

            Assert.IsTrue(result.Count != 0, "no items shown"); ;

        }








    }
}

