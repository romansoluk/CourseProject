using BusinessLogic.Solid;
using DAL.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProjectWF
{
    class Program
    {

        static void Main()
        {
            //Console.WriteLine();
            //NewBL();
            //NewCode();
            //Console.ReadLine();
        }



        /* private static void NewBL()
         {
             string connStr = ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString;
             ItemDAL dal = new ItemDAL(connStr);


             Shipper shipper = new Shipper(dal);
             ItemDTO m = new ItemDTO
             {
                 Name = "Polka dot dress red",
                 Price = (float)800.00,
                 OnStock = 150
             };
             m = shipper.AddItem(m);
             // dal.GetAllItems();
         }


         private static void NewCode()
         {
             ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);

             ItemDTO m = new ItemDTO
             {
                 Name = "Polka dot dress red",
                 Price = (float)800.00,
                 OnStock = 150
             };
             m = dal.CreateItem(m);
             Console.WriteLine($"New item ID: {m.ItemID}");

             foreach (var item in dal.GetAllItems())
             {
                 Console.WriteLine($"{item.ItemID}\t{item.Name}\t{item.Price}");
             }

             Console.WriteLine($"Deleting movie ID: {m.ItemID}");
             dal.DeleteItem(m.ItemID);
             foreach (var item in dal.GetAllItems())
             {
                 Console.WriteLine($"{item.ItemID}\t{item.Name}\t{item.Price}");
             }
         }*/
     }

    }

