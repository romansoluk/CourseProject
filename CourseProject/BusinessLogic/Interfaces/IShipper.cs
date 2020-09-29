using BusinessLogic.Solid;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IShipper
    {

        ShipperDTO AddShipper(ShipperDTO shipper);
        ShipperDTO ChangeShipper(ShipperDTO shipper);
        void RemoveShipper(int ShipperID);
        ShipperDTO GetShipper(int ShipperID);
    }
}
