using BusinessLogic.Interfaces;
using DAL.Concrete;
using DAL.Interfaces;
using DTO;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace BusinessLogic.Solid
{
    public class Item:IItem
    {
      
        private readonly IItemDAL _itemDAL;
        //private readonly ItemDTO dal;
           

      public Item(IItemDAL itemDAL)
        {
            _itemDAL = itemDAL;
        }

        public ItemDTO AddItem(ItemDTO item)
            {
            // ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);

            item = new ItemDTO
            {
                Name = Console.ReadLine(),
                Price=Convert.ToDouble(Console.ReadLine()),
                OnStock=Convert.ToInt32(Console.ReadLine())
            };

            

            return _itemDAL.CreateItem(item);
            }

        public void ShowItems()
        {
            Console.WriteLine("ItemID\tName\t\tPrice\tOnStock");
            foreach (var item in _itemDAL.GetAllItems())
            {
                Console.WriteLine($"{item.ItemID}\t{item.Name}\t{item.Price}\t{item.OnStock}");
                //Console.WriteLine($"{item.OnStock}");

            }
        }

    }
}


