using System;
class Program
{
    static void Main(string[] args)
    {
        string var;
        Console.Write("Enter your marks: ");
        var = Console.ReadLine();
        int marks = int.Parse(var);
        if (marks > 50)
        {
            Console.WriteLine("You are Passed");
        }
        else if (marks < 50)
        {
            Console.WriteLine("You are failed");
        }
        
    }
}