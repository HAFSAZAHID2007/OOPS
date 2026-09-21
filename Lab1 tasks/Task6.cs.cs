using System;
class Program
{
    static void Main(string[] args)
    {
        string var;
        var = Console.ReadLine();
        Console.WriteLine("You have inputted: ");
        int num = int.Parse(var);
        Console.WriteLine("The number is: ");
        Console.Write(num);
        Console.ReadKey(); 
    }
}