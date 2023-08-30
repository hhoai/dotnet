// See https://aka.ms/new-console-template for more information

Console.WriteLine("nhap so phan tu cua mang: ");
int n = int.Parse(Console.ReadLine());
int[] a = new int[n];

// nhap mang
for (int i = 0; i  < n; i++)
{
    Console.Write("a[{0}] = ", i);
    a[i] = int.Parse(Console.ReadLine());

}
// max
int flag = a[0];
for (int i = 0; i < n; i++)
    if (flag < a[i])
        flag = a[i];
Console.WriteLine("Gia tri lon nhat trong mang: {0}", flag);

// min
flag = a[0];
for (int i = 0; i < n; i++)
    if (flag > a[i])
        flag = a[i];
Console.WriteLine("Gia tri nho nhat trong mang: {0}", flag);

// tong
flag = 0;
for (int i = 0; i < n; i++)
    flag += a[i];
Console.WriteLine("Tong gia tri cac phan tu trong mang: {0}", flag);
