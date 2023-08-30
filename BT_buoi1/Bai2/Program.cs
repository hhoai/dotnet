// See https://aka.ms/new-console-template for more information
Console.WriteLine("Nhap luong, thuong: ");

double luong = double.Parse(Console.ReadLine());
double thuong = double.Parse(Console.ReadLine());

double thunhap = luong + thuong;
double thue;

if (thunhap < 9000000)
    Console.WriteLine("Khong phai dong thue.");

else
{
    if (thunhap < 15000000)
    {
        thue = thunhap * 0.1;
    }
    else if (thunhap < 30000000)
    {
        thue = thunhap * 0.15;
    }
    else
    {
        thue = thunhap * 0.2;
    }
    Console.WriteLine("Thue phai dong: {0}", thue);
}
