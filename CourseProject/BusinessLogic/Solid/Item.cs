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
        
           

      public Item(IItemDAL itemDAL)
        {
            _itemDAL = itemDAL;
        }

        public ItemDTO AddItem(ItemDTO item)
            {
            Console.WriteLine("Enter NEW ITEM DETAILS (NAME, PRICE, ON STOCK");
            item = new ItemDTO
            {
                Name = Console.ReadLine(),
                Price=Convert.ToDouble(Console.ReadLine()),
                OnStock=Convert.ToInt32(Console.ReadLine())
            };

            

            return _itemDAL.CreateItem(item);
            }


        public void RemoveItem(int ItemID)
        {
            Console.WriteLine("ENTER ITEM ID TO DELETE:");
            ItemDTO item = new ItemDTO();
            item.ItemID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Deleting item ID: {item.ItemID}");
             _itemDAL.DeleteItem(item.ItemID);
        }

        public ItemDTO GetItem(int ItemID)
        {
            return _itemDAL.GetItemById(ItemID);
        }

        public void ShowItems()
        {
            Console.WriteLine("LIST OF ALL ITEMS ON STOCK:\n");
            Console.WriteLine("ItemID\tName\t\tPrice\tOnStock");
            foreach (var item in _itemDAL.GetAllItems())
            {
                Console.WriteLine($"{item.ItemID}\t{item.Name}\t{item.Price}\t{item.OnStock}");

            }
        }

        public void ShowItemsSorted(int SortParameter)
        {
            Console.WriteLine("Enter number to get items sorted \n 1-Price Ascending \n 2-Price Descending \n 3-Newer to Older \n Anything else for older first");
            Console.WriteLine("ItemID\tName\t\tPrice\tOnStock");
            foreach (var item in _itemDAL.GetAllItemsSorted(SortParameter))
            {
                Console.WriteLine($"{item.ItemID}\t{item.Name}\t{item.Price}\t{item.OnStock}");
                
            }
        }

        public ItemDTO ChangeItem(ItemDTO item)
        {
            Console.WriteLine("CHANGE ITEM DETAILS:\n");
            Console.WriteLine("ItemID, new Price, left OnStock");
            item = new ItemDTO
            {
                ItemID = Convert.ToInt32(Console.ReadLine()),
                Price = Convert.ToDouble(Console.ReadLine()),
                OnStock = Convert.ToInt32(Console.ReadLine())
            };


            return _itemDAL.UpdateItem(item);
        }



    }
}


