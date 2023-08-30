using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2_class
{
    class Program
    {
        static void Main(string[] args)
        {
            DSCongNhan listcn = new DSCongNhan();

            listcn.NhapDS();

            Console.WriteLine("\n------- DANH SACH CONG NHAN ----------");
            Console.WriteLine($"{"Ho Ten",-20}{"Gioi Tinh",-10}{"Nam Sinh",-10}{"Ten CT",-20}{"HS Luong",-10}{"Thu Nhap",-10}");
            listcn.XuatDS();

            //max hsl
            listcn.HSLmax();

            // xoa cong nhan
            listcn.XoaCN();

            // tim cong nhan theo nam sinh
            listcn.TimCN();

            Console.ReadLine();

        }
    }
}
