using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2_class
{
    class Person
    {
        public string hoten { get; set; }
        public string gioitinh { get; set; }
        public int namsinh { get; set; }
        public Person()
        {
            hoten = "";
            gioitinh = "";
            namsinh = 0;
        }

        public Person(string ht, string gt, int ns)
        {
            hoten = ht;
            gioitinh = gt;
            namsinh = ns;
        }

        public virtual void Nhap()
        {
            Console.Write("Nhap ho ten: ");
            hoten = Console.ReadLine();
            Console.Write("Nhap gioi tinh: ");
            gioitinh = Console.ReadLine();
            Console.Write("Nhap nam sinh: ");
            namsinh = int.Parse(Console.ReadLine());
        }
        public virtual void Xuat()
        {
            Console.Write($"{hoten, -20}{gioitinh, -10}{namsinh, -10}");
        }
    }
}
