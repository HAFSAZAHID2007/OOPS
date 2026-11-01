using System;
class Program
{
    static void Main(string[] args) { 
    
     
int[] num = new int[3];
for(int i = 0; i < 3; i++)
{
    Console.Write("Enter a number: ",i);
    num[i] = int.Parse(Console.ReadLine());
}
int largest = num[0];
for(int i = 0; i < 3; i++)
{
    if (num[i] > largest)
    {
        largest = num[i];
    }
}
Console.WriteLine("The Largest num: {0} " , largest);
Console.ReadKey();
    }
}