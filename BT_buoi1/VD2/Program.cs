// See https://aka.ms/new-console-template for more information
using System.Reflection.Emit;

Console.WriteLine("nhap diem trung binh: ");
double dtb = double.Parse(Console.ReadLine());
string xeploai = "";
if (dtb < 0 || dtb > 10)
    Console.WriteLine("diem khong hop le!");
else
{
    if (dtb < 5)
        xeploai = "yeu";
    else if (dtb < 7)
        xeploai = "trung binh";
    else if (dtb < 8)
        xeploai = "kha";
    else
        xeploai = "gioi";
    Console.WriteLine("xep loai: {0}", xeploai);
}
Console.ReadLine();