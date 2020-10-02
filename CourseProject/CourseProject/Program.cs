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


            Menu console = new Menu(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            ConsoleProgramFunctions Login = new ConsoleProgramFunctions(ConfigurationManager.ConnectionStrings["Shipper"].ConnectionString);
            int user = Login.Login();
            console.MENU(user);
            Console.ReadLine();
        }




    }
}


