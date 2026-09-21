using System;
class Program
{
    static void Main(string[] args)
    {
        int n1, n2, n3;
        Console.Write("Enter first number: ");
        n1 = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        n2 = int.Parse(Console.ReadLine());
        Console.Write("Enter third number: ");
        n3 = int.Parse(Console.ReadLine());
        if (n1 > n2 && n2 > n3)
        {
            Console.WriteLine("n1 is the largest");
        }
        if (n2 > n3 && n2 > n1)
        {
            Console.WriteLine("n2 is the largest");
        }
        if (n3 > n2 && n3 > n1)
        {
            Console.WriteLine("n3 is the largest");
        }
        Console.ReadKey(); 
    }
}