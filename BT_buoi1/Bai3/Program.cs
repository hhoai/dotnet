// See https://aka.ms/new-console-template for more information
Console.WriteLine("nhap thang, nam: ");

int thang = int.Parse(Console.ReadLine());
int nam = int.Parse(Console.ReadLine());

switch (thang)
{
    case 1: case 3: case 5: case 7: case 8: case 10: case 12:
        Console.WriteLine("thang {0}, nam {1} co 31 ngay.", thang, nam);
        break;
    case 4: case 6: case 9: case 11:
        Console.WriteLine("thang {0}, nam {1} co 30 ngay.", thang, nam);
        break;
    case 2:
        if (nam % 4 == 0)
        Console.WriteLine("thang {0}, nam {1} co 29 ngay.", thang, nam);
        else
        Console.WriteLine("thang {0}, nam {1} co 28 ngay.", thang, nam);
        break;
    default:
        Console.WriteLine("nhap sai thong tin.");
        break;
}