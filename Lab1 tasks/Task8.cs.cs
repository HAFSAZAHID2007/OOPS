using System;
class Program
{ 
    static void Main(string[] args)
    {
        string var;
        float len;
        float area;
        Console.Write("Enter Length: ");
        var = Console.ReadLine();
        len = float.Parse(var);
        area = len * len;
        Console.Write("The Area is: ");
        Console.Write(area);
        Console.ReadKey(); 
    }

}