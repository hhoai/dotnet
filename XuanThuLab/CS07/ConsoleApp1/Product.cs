using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Product
    {
        public string name;
        public Product()
        {
            name = "";
        }
        public Product(string name)
        {
            this.name = name;
        }

        public void Output()
        {
            Console.WriteLine($"Ten SP: {name}");
        }
    }
}
