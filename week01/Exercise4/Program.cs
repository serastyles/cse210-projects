using System;
using System.Collections.Generic;
using System.Linq;
class Program
{

    static void Main(string[] args)

    {
        List<int> numbers = new List<int>();
        string input;
        Console.WriteLine("Please enter a list of numbers, type 0 when finished.");
        while (true)
        {
            Console.WriteLine("Enter a number: ");
            input = Console.ReadLine();

            //convert input to integer
            int number = int.Parse(input);

            if (number == 0)
            {
                break;
            }

            //Add the number to the list 
            numbers.Add(number);
        }
        Console.WriteLine("You entered the following numbers:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }

        if (numbers.Count > 0)
        {
            // calculating the average
            double average = numbers.Average();
            int max = numbers.Max();
            Console.WriteLine($"The avearge is:{average}");
            Console.WriteLine($"The largest number is: {max} ");
        }
        else
        {
            Console.WriteLine("\n No numbers were entered.");
        }
        // Find the smallest positive number
        var positiveNumbers = numbers.Where(n => n > 0);
        if (positiveNumbers.Any())
        {
            int minPositive = positiveNumbers.Min();
            Console.WriteLine($"The smallest positive number is: {minPositive}");
        }
        else
        {
            Console.WriteLine("There were no positive numbers entered.");
        }

        numbers.Sort();
       
        Console.WriteLine("\n The sorted list is:  ");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);   
        }   
        }
        }

           
    
