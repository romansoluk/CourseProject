using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    class AddToOrderDAL : IAddToOrderDAL
    {
        private string connectionString;

        public AddToOrderDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public AddToOrderDTO AddToOrder(AddToOrderDTO addtoorder )
        {
            throw new NotImplementedException();
        }
    }
}
