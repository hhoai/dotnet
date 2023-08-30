using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product table = new Product("o");
            table.Output();

            Product phone = new Product();
            phone.name = "hhh";
            phone.Output();

            Console.ReadLine();
        }
    }
}
