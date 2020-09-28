using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public int CustomerIDKEY { get; set; }
        public int ShipperIDKEY { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

    }
}
