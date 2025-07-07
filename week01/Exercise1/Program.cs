using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your first name?.");
        Console.WriteLine("What is your last name?");
        string firstname = Console.ReadLine();
        String lastname = Console.ReadLine();
        Console.WriteLine($"Your name is {lastname}, {firstname} {lastname}.");
    }
}