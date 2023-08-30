// See https://aka.ms/new-console-template for more information

Console.WriteLine("Nhap chuoi: ");
string a = Console.ReadLine();

for (int i = 0; i < a.Length; i++)
    Console.WriteLine(a[i]);

Console.WriteLine("");

for (int i = 0; i < a.Length; i++)
{
    Console.Write(a[i]);
    if (a[i] == 32)
        Console.Write("\n");
}
Console.WriteLine("\n");

a = a.Replace(" ", string.Empty);
//sử dụng vòng lặp while và for để lặp và đếm số lần xuất hiện của ký tự
while (a.Length > 0)
{
    Console.Write(a[0] + " : ");
    int count = 0;
    for (int j = 0; j < a.Length; j++)
    {
        if (a[0] == a[j])
        {
            count++;
        }
    }
    Console.WriteLine(count);
    a = a.Replace(a[0].ToString(), string.Empty);
}