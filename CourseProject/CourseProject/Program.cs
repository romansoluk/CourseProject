using BusinessLogic.Solid;
using DAL.Concrete;
using DAL.Interfaces;
using System;
using System.Configuration;
using System.Windows.Forms;
using BusinessLogic.Interfaces;

namespace CourseProjectWF
{
    class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            IShipperDAL _shipperDAL = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            IItemDAL _itemDAL = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            ICustomerDAL _customerDAL = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            IOrderDAL _orderDAL = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString); ;
            IAddToOrderDAL _addtoorderDAL = new AddToOrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
           
            
            ICustomer user2 = new Customer(_customerDAL, _addtoorderDAL, _itemDAL, _orderDAL);
            IUser user1 = new User(_shipperDAL, _itemDAL, _customerDAL, _orderDAL, _addtoorderDAL);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RoleChoiceForm(user1,user2));
        }




    }
}


