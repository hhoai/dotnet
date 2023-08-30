// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;

Console.WriteLine("nhap lan luot cac he so a, b, c: ");

int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());

float  d = b * b - 4 * a * c;

if (a == 0)
{
    Console.WriteLine("khong phai PT bac 2.");
}
else
{
    if (d < 0)
        Console.WriteLine("PT vo nghiem.");
    else if (d == 0)
        Console.WriteLine("PT co nghiem kep x1 = x2 = {0}.", -b / (2 * a));
    else
        Console.WriteLine("PT co 2 nghiem x1 = {0}, x2 = {1}", (-b + Math.Sqrt(d)) / (2 * a), (-b - Math.Sqrt(d)) / (2 * a));
}
Console.ReadLine();