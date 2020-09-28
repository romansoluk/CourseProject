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
        ShipperDTO GetShipper(ShipperDTO shipper);
        void Login(); 
        ShipperDTO GetShipperById(int ShipperID);
        ShipperDTO CreateShipper(ShipperDTO shipper);
    }
}
