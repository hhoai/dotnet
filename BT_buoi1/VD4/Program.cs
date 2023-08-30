// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int x;
do
{
    Console.WriteLine("nhap so nguyen (0 < x <= 100): ");
    x = int.Parse(Console.ReadLine());
}
while (x <= 0 || x > 100);
for (int i = 100; i > 49; i--)
    if (i % x == 0)
    {
        Console.WriteLine("so nguyen lon nhat trong khoang 1 - 100 chia het cho x: {0}", i);
        break;
    }
Console.ReadLine();
