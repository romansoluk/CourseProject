using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IShipperDAL
    {
       
        ShipperDTO CreateShipper(ShipperDTO shipper);
        ShipperDTO GetShipperById(int ShipperID);
        ShipperDTO GetShipperByLogin(string ShipperLogin);
        ShipperDTO UpdateShipper(ShipperDTO shipper);
        void DeleteShipper(int ShipperID);
        bool Login(string password, string Login);

    }
}
