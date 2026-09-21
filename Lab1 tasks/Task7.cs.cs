using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Floating Point Value: ");
       string  var = Console.ReadLine();
        float num = float.Parse(var);
        Console.WriteLine("TheFloating Value is: ");
        Console.Write(num);
        Console.ReadKey(); 
    }
}