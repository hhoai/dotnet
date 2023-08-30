// See https://aka.ms/new-console-template for more information
Console.WriteLine("Nhap vao so thu: ");
int thu = int.Parse(Console.ReadLine());
switch(thu)
{
    case 2:
        Console.WriteLine("Thu hai");
        break;  
    case 3:
        Console.WriteLine("Thu ba");
        break;
    case 4:
        Console.WriteLine("Thu tu");
        break;
    case 5:
        Console.WriteLine("Thu nam");
        break;
    case 6:
        Console.WriteLine("Thu sau");
        break;
    case 7:
        Console.WriteLine("Thu bay");
        break;
    case 8:
        Console.WriteLine("Chu nhat");
        break;
    default:
        Console.WriteLine("thong tin nhap vao khong hop le!");
        break;
}    
Console.ReadLine();