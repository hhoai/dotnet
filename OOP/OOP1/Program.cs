using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    class Program
    {
        static List<NhanVien> dsnv = new List<NhanVien>();
        static void Main(string[] args)
        {
            int choose;

            do
            {
                Console.WriteLine("-------- Menu ---------");
                Console.WriteLine("1. Them");
                Console.WriteLine("2. Hien thi ds");
                Console.WriteLine("3. Sap xep");
                Console.WriteLine("4. Thoat");
                Console.WriteLine("Moi nhap lua chon.");

                choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        AddNhanVien();
                        break;
                    case 2:
                        Show();
                        break;
                    case 3:
                        Sort();
                        break;
                    case 4:
                        Console.WriteLine($"Kết thúc");
                        break;
                    default:
                        Console.WriteLine($"Không có lựa chọn này");
                        break;
                }
            }
            while (choose !=  4);

        }
        public static void AddNhanVien()
        {
            NhanVien nhanvien = new NhanVien();
            Console.Write("Ten nhan vien: ");
            nhanvien.hoTen = Console.ReadLine();
            Console.Write("Dia chi: ");
            nhanvien.diaChi = Console.ReadLine();
            Console.Write("He so luong: ");
            nhanvien.hsLuong = float.Parse(Console.ReadLine());
            Console.Write("Luong co ban: ");
            nhanvien.luongCB = double.Parse(Console.ReadLine());
            Console.Write("Ma NV: ");
            nhanvien.maNV = Console.ReadLine();
            Console.Write("Chuc vu: ");
            nhanvien.chucVu = Console.ReadLine();

            if (dsnv.Count == 0)
            {
                dsnv.Add(nhanvien);
                Console.WriteLine("Them nhan vien thanh cong!");
            }
            else
            {
                bool exist = false;
                foreach (var el in dsnv)
                {
                    if (el.maNV == nhanvien.maNV)
                    {
                        Console.WriteLine($"Ma nhan vien {nhanvien.maNV} da ton tai!");
                        exist = true;
                        break;
                    }
                    
                }
                if (!exist)
                {
                    dsnv.Add(nhanvien);
                    Console.WriteLine("Them nhan vien thanh cong!");
                }
            }
            Console.WriteLine();
        }
        public static void Show()
        {
            Console.WriteLine("\n-------- DANH SACH NHAN VIEN --------");
            Console.WriteLine($"{"Ho Ten",-20}{"Dia Chi",-10}{"HS Luong",-10}{"Luong CB",-10}{"Luong", -10}{"Ma NV",-6}{"Chuc Vu",-15}");
            foreach (var el in dsnv)
            {
                Console.WriteLine($"{el.hoTen,-20}{el.diaChi,-10}{el.hsLuong,-10}{el.luongCB,-10}{Math.Round(el.Luong(),0), -10}{el.maNV,-6}{el.chucVu,-15}");
            }
            Console.WriteLine();
        }
        public static void Sort()
        {
            for (int i = 0; i < dsnv.Count; i++)
                for (int j = i; j < dsnv.Count; j++)
                    if (dsnv[i].Luong() > dsnv[j].Luong())
                    {
                        NhanVien temp = dsnv[i];
                        dsnv[i] = dsnv[j];
                        dsnv[j] = temp;
                    }
            Show();
        }
    }
}

