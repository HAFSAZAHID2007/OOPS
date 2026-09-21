using System;
class Program
{
    static void Main(string[] args)
    {
        int num;
        int sum = 0;
        do
        {
            Console.Write("Enter the number: ");
            num = int.Parse(Console.ReadLine());
            sum = sum + num;
        }
        while (num != -1);
        sum = sum + 1;

        Console.WriteLine("Total sum is: {0} ", sum);
    }
}