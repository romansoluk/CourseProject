using BusinessLogic.Solid;
using DAL.Concrete;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleProject;
using System.Windows.Forms;

namespace CourseProject
{
    class Program
    {
        static void Main(string[] args)
        {


            ConsoleLogic console = new ConsoleLogic(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);

            console.Menu();
            //Console.WriteLine(console.Menu());
            //OldCode();
            //NewBL();
            // NewCode();
            //OrderCode();
            // ConsoleOperations();
            Console.ReadLine();
        }



        private static void ConsoleOperations()
        {
           /* ConsoleProgram log = new ConsoleProgram(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            Console.WriteLine(log.Login());
            Console.ReadLine();*/

           
        }

        private static void OrderCode()
        {

            /* ICustomerDAL dal = new CustomerDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);

             //OrderDTO m = new OrderDTO();



             CustomerDTO m = new CustomerDTO
             {


                 EMail = "levie@gmail.com",
                 Addres = "Right Bank St 15",
                 Phone = "+380944463253",
                 Description = "No Description"
             };

              m = dal.CreateCustomer(m);*/


            IShipperDAL dal = new ShipperDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);




            //OrderDTO m = new OrderDTO();

            /* string num = Console.ReadLine();
             byte[] password = new byte[num.Length];

             for (int i = 0; i <= num.Length - 1; i++)
             {
                 password[i] = Convert.ToByte(num[i]);
             }

             ShipperDTO m = new ShipperDTO
             {
                 Login = "Bevau",
                 Password = password,
                 EMail = "bevau@gmail.com",
                 Addres = "Center Sq 45",
                 Phone = "+380985463253",
                 Description = "No Description"
             };

             m = dal.CreateShipper(m);*/

            string str = "";
            for (int i = 0; i < dal.GetShipperById(3).Password.Length; i++)
            {
                str += Convert.ToString(Convert.ToChar(dal.GetShipperById(8).Password[i]));
            }
            Console.WriteLine(str);







            //for (int i = 0; i < dal.GetShipperById(3).Password.Length; i++)
            //{
            //  Console.WriteLine(dal.GetShipperById(3).Password[i]);
            //}



            //Console.WriteLine(Convert.ToBase64String(dal.GetShipperById(3).Password)/*+ '\n' + dal.GetOrderById(1).CustomerIDKEY + '\n' + dal.GetOrderById(1).ShipperIDKEY + '\n'*/);
            // Console.WriteLine(dal.GetOrderById(1).Date);
            //for(int i=0; i<=19; i++)
            //{
            //    Console.WriteLine(dal.GetShipperById(1).Password);
            //}
            //string str = System.Text.Encoding.Default.GetString(dal.GetShipperById(3).Password);
            //Console.WriteLine(str);
            //Convert.ToString(dal.GetShipperById(1).Password);
            Console.ReadLine();
        }

            
        private static void NewBL()
        {
            string connStr = ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString;
            ShipperDAL dal = new ShipperDAL(connStr);


            Shipper manager = new Shipper(dal);
            ShipperDTO item = new ShipperDTO();
            manager.AddShipper(item);

            //manager.ShowItems();

            //ItemDTO m = new ItemDTO
            //{
            //    Name = "Dark brown fake leather belt",
            //    Price = (float)700.00,
            //    OnStock = 175
            //};
            //m = manager.AddItem(m);

            Console.WriteLine("DONE");
            Console.ReadLine();
        }


        

        private static void NewCode()
        {
        //    IOrderDAL dal = new OrderDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);

        //    OrderDTO m = new OrderDTO();



            //Item manager = new Item(dal);
            //manager.ShowItems();

            //Console.WriteLine(dal.GetOrderById(1).CustomerIDKEY /*+ '\n' + dal.GetOrderById(1).CustomerIDKEY + '\n' + dal.GetOrderById(1).ShipperIDKEY + '\n'*/);
            // Console.WriteLine(dal.GetOrderById(1).Date);

           ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);

            /*ItemDTO m = new ItemDTO
            {
                ItemID=1,
                Price = 500,
                OnStock=100
            };

            dal.UpdateItem(m);*/









            //Item manager = new Item(dal);
            //manager.ShowItems();

            //Console.WriteLine(dal.GetItemById(1).Name);

            ItemDTO m = new ItemDTO
             {
                 Name = "Grey Pants",
                 Price = 1590.00,
                 OnStock = 50
             };
             m = dal.CreateItem(m);
             Console.WriteLine($"New item ID: {m.ItemID}");
             


            // foreach (var item in dal.GetAllItemsSorted(2))
            //{
            //  Console.WriteLine($"{item.ItemID}\t{item.Name}\t{item.Price}\t{item.OnStock}");
            //Console.WriteLine($"{item.OnStock}");


            //foreach (var item in dal.GetAllItems())
            //{
            //   Console.WriteLine($"{item.ItemID}\t{item.Name}\t{item.Price}\t{item.OnStock}");
            //    //Console.WriteLine($"{item.OnStock}");

            //}
            //m.ItemID = 9;
            //Console.WriteLine($"Deleting item ID: {m.ItemID}");
            //dal.DeleteItem(m.ItemID);
            //foreach (var movie in dal.GetAllMovies())
            //{
            //    Console.WriteLine($"{movie.MovieID}\t{movie.Title}\t{movie.Year}");
            //}
            // }

            //private static void OldCode()
            //{
            //    string connStr = ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString;

            //    using (SqlConnection conn = new SqlConnection(connStr))
            //    using (SqlCommand comm = conn.CreateCommand())
            //    {
            //        comm.CommandText = "select * from Movie";
            //        conn.Open();
            //        SqlDataReader reader = comm.ExecuteReader();

            //        while (reader.Read())
            //        {
            //            Console.WriteLine($"{reader["MovieID"]}\t{reader["Title"]}\t{reader["Year"]}");
            //        }
            //    }

            //    using (SqlConnection conn = new SqlConnection(connStr))
            //    using (SqlCommand comm = conn.CreateCommand())
            //    {
            //        conn.Open();
            //        comm.CommandText = "update Movie set Year = @newYear where MovieID = 1";
            //        comm.Parameters.Clear();
            //        comm.Parameters.AddWithValue("@newYear", 2020);
            //        int affected = comm.ExecuteNonQuery();

            //        Console.WriteLine($"Affected rows: {affected}");
            //    }

            //    using (SqlConnection conn = new SqlConnection(connStr))
            //    using (SqlCommand comm = conn.CreateCommand())
            //    {
            //        conn.Open();
            //        comm.CommandText = "select max(Year) from Movie";
            //        int year = (int)comm.ExecuteScalar();

            //        Console.WriteLine($"Max year: {year}");
            //    }
            Console.WriteLine("DONE");
            Console.ReadLine();
            }


        }

    }


