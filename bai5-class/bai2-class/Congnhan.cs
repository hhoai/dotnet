using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2_class
{
    class Congnhan : Person
    {
        public string tenct { get; set; }
        public float hsluong { get; set; }
        public Congnhan() : base()
        {
            tenct = "";
            hsluong = 0;
        }

        public Congnhan(string ht, string gt, int ns, string tenct, float hsl) : base(ht, gt, ns)
        {
            this.tenct = tenct;
            hsluong = hsl;
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap ten cong ty: ");
            tenct = Console.ReadLine();
            Console.Write("Nhap he so luong: ");
            hsluong = float.Parse(Console.ReadLine());
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.Write($"{tenct,-20}{hsluong,-10}");
        }
        public double ThuNhap()
        {
            return hsluong * 850000;
        }
       
    }
}
