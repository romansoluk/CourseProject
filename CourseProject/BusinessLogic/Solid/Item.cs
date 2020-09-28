using BusinessLogic.Interfaces;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return _itemDAL.CreateItem(item);
            }

        public void ShowItems()
        {
            foreach (var item in _itemDAL.GetAllItems())
            {
                Console.WriteLine($"{item.ItemID}\t{item.Name}\t{item.Price}\t{item.OnStock}");
                //Console.WriteLine($"{item.OnStock}");

            }
        }

    }
}


