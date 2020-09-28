using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AddToOrderDTO
    {
        public int OrderIDKEY { get; set; }
        public int ItemIDKEY { get; set; }
        public int Amount { get; set; }
       
    }
}
