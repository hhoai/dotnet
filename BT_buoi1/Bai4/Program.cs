// See https://aka.ms/new-console-template for more information

int n;
do
{
    Console.WriteLine("nhap so nguyen duong n (0<n<=100): ");
    n = int.Parse(Console.ReadLine());
}
while (n <= 0 || n > 100);

int tong = 0;

for (int i = 1; i <= n; i++)
    tong += i;
Console.WriteLine("Tong S = {0}", tong);