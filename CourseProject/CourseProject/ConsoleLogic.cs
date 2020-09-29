using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Solid;
using ConsoleProject;
using DAL.Concrete;
using DAL.Interfaces;
using DTO;
using BusinessLogic;

namespace CourseProject
{
    public class ConsoleLogic
    {

        private string connectionString;

        public ConsoleLogic(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int LoginConsole()
        {
            Console.WriteLine("");
            int choice=Convert.ToInt32(Console.ReadLine());

            ConsoleProgramFunctions Login = new ConsoleProgramFunctions(connectionString);
            if(choice==1)
            {
                return Login.Login();
            }
            
            else { return 0; }
            
        }

        public bool CheckIfLogined()
        {
            if(LoginConsole()==0)
            {
                return false;
            }

            return true;
        }



        public void Menu()
        {
            ConsoleProgramFunctions Login = new ConsoleProgramFunctions(connectionString);
            //Console.WriteLine(Login.Login());
            int user = Login.Login();


           
           


        }

    }
}
