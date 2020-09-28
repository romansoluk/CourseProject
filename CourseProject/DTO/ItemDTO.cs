using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ItemDTO
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int OnStock { get; set; }
    }
}
