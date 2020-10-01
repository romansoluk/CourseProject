using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DAL.Concrete;
using DAL.Interfaces;
using DTO;

namespace BusinessLogic.Solid
{
    public class Shipper : IShipper
    {
        private readonly IShipperDAL _shipperDAL;
      


        public Shipper(IShipperDAL shipperDAL)
        {
            _shipperDAL = shipperDAL;
        }

        public ShipperDTO AddShipper(ShipperDTO shipper)
        {
           
            ConsoleProject.PasswordActions password = new ConsoleProject.PasswordActions();


            Console.WriteLine("Login, Password, Email, Address, Phone, Descrition: ");
            shipper = new ShipperDTO
          {
          Login = Console.ReadLine(),
          Password = password.PasswordEncryption(/*encrypted=*/Console.ReadLine()),
          EMail = Console.ReadLine(),
          Addres = Console.ReadLine(),
          Phone = Console.ReadLine(),
          Description = Console.ReadLine()
          };

          return _shipperDAL.CreateShipper(shipper);
}


        public void RemoveShipper(int ShipperID)
        {
            ShipperDTO shipper = new ShipperDTO();
            shipper.ShipperID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Deleting shipper ID: {shipper.ShipperID}");
            _shipperDAL.DeleteShipper(shipper.ShipperID);
        }

        public ShipperDTO GetShipper(int ShipperID)
        {
            ShipperID = Convert.ToInt32(Console.ReadLine());
            return _shipperDAL.GetShipperById(ShipperID);
        }

        public ShipperDTO ChangeShipper(ShipperDTO shipper)
        {
           
            Console.WriteLine("ShipperID, new EMail, Address, Phone, Description");
            shipper = new ShipperDTO
            {
                ShipperID = Convert.ToInt32(Console.ReadLine()),
                EMail= Console.ReadLine(),
                Addres = Console.ReadLine(),
                Phone = Console.ReadLine(),
                Description =Console.ReadLine()

            };


            return _shipperDAL.UpdateShipper(shipper);
        }
    }
}
