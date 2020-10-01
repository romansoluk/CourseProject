using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    interface IAddToOrder
    {
        AddToOrderDTO AddPosition(AddToOrderDTO addtoorder);
        void DeletePosition(int OrderIDKEY);
        List<AddToOrderDTO> SameOrderPositions(int OrderIDKEY);
    }
}
