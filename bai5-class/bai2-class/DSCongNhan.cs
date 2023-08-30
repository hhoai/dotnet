using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2_class
{
    class DSCongNhan
    {
        List<Congnhan> listcn = new List<Congnhan>();

        public void NhapDS()
        {
            Console.WriteLine("nhap so cong nhan");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Congnhan a = new Congnhan();
                a.Nhap();
                listcn.Add(a);

            }

        }
        public void XuatDS()
        {
            foreach (var el in listcn)
            {
                el.Xuat();
                Console.WriteLine($"{ el.ThuNhap(),-10}");
            }
        }

        public void HSLmax()
        {
            float maxHsL = listcn[0].hsluong;
            for (int i = 0; i < listcn.Count; i++)
                if (maxHsL <= listcn[i].hsluong)
                    maxHsL = listcn[i].hsluong;

            Console.WriteLine("\n------------ DANH SACH CONG NHAN CO HSL CAO NHAT ----------");
            Console.WriteLine($"{"Ho Ten",-20}{"Gioi Tinh",-10}{"Nam Sinh",-10}{"Ten CT",-20}{"HS Luong",-10}{"Thu Nhap",-10}");
            foreach (var el in listcn)
                if (el.hsluong == maxHsL)
                {
                    el.Xuat();
                    Console.WriteLine($"{ el.ThuNhap(),-10}");
                }
        }

        public void XoaCN()
        {
            Console.Write("\nNhap ho ten cong nhan can xoa: ");
            string nameDelete = Console.ReadLine();
            for (int i = 0; i < listcn.Count; i++)
                if (listcn[i].hoten == nameDelete)
                    listcn.Remove(listcn[i]);

            Console.WriteLine("\n------------ DANH SACH CONG NHAN SAU KHI XOA ----------");
            Console.WriteLine($"{"Ho Ten",-20}{"Gioi Tinh",-10}{"Nam Sinh",-10}{"Ten CT",-20}{"HS Luong",-10}{"Thu Nhap",-10}");
            foreach (var el in listcn)
            {
                el.Xuat();
                Console.WriteLine($"{ el.ThuNhap(),-10}");
            }
        }

        public void TimCN()
        {
            Console.Write("\nNhap nam sinh cong nhan can tim: ");
            int ns = int.Parse(Console.ReadLine());

            Console.WriteLine("\n------------ DANH SACH CONG NHAN CAN TIM ----------");
            Console.WriteLine($"{"Ho Ten",-20}{"Gioi Tinh",-10}{"Nam Sinh",-10}{"Ten CT",-20}{"HS Luong",-10}{"Thu Nhap",-10}");
            foreach (var el in listcn)
                if (el.namsinh == ns)
                {
                    el.Xuat();
                    Console.WriteLine($"{ el.ThuNhap(),-10}");
                }

        }
    }
}
