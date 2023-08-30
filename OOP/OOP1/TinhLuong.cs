using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    class TinhLuong
    {
        public string hoTen { get; set; }
        public string diaChi { get; set; }
        public float hsLuong { get; set; }
        public double luongCB { get; set; }

        public TinhLuong()
        {
            hoTen = diaChi = "";
            hsLuong = 0;
            luongCB = 1000000;
        }
        public TinhLuong (string ht, string dc, float hsl, double lcb)
        {
            hoTen = ht;
            diaChi = dc;
            hsLuong = hsl;
            luongCB = lcb;
        }

        public virtual double Luong ()
        {
            return hsLuong * luongCB;
        }
    }
}
