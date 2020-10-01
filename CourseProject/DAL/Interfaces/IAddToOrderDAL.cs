using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAddToOrderDAL
    {
        AddToOrderDTO CreateAddToOrder(AddToOrderDTO addtoorder);
        void DeleteAddToOrder(int OrderIDKEY); 
        List<AddToOrderDTO> FromSameOrder(int OrderIDKEY); 
    }
}
