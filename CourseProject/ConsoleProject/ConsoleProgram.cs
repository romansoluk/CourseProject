using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace ConsoleProject
{
    public class ConsoleProgram
    {

        private string connectionString;

        public ConsoleProgram(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Login()
        {

            Console.WriteLine("Login to continue:\n");
            Console.WriteLine("Login: ");
            string login= Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            return true;
        }

    }
}
