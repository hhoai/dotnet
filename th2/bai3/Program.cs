// See https://aka.ms/new-console-template for more information

List<int> list_a = new List<int>();

int n;
/*
do
{
    Console.WriteLine("nhap so phan tu trong mang: ");  
    n = int.Parse(Console.ReadLine());
}
while (n <= 0 || n > 100);
*/

Console.WriteLine("nhap phan tu trong mang (k/ K de dung): ");
string inp;
do
{
    inp = Console.ReadLine();
    int a = int.Parse(inp);
    list_a.Add(a);
}
while (inp != "k" || inp != "K");
    
for (int i = 0; i < list_a.Count; i++)
{
    int tmp = int.Parse(Console.ReadLine()) ;
    list_a.Add(tmp);
}

foreach (var el in list_a)
{
    Console.Write(el + " ");
}

for (int i = 0; i < list_a.Count; i++)
    if (list_a[i] < 0)
        list_a.RemoveAt(i);

list_a.Sort();

Console.WriteLine();
foreach (var el in list_a)
{
    Console.Write(el + " ");
}