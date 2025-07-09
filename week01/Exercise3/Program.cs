using System;

class Program

{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);
        // Ask for the user's guess
        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());

        // Compare the guess with the magic number
        if (guess < magicNumber)
        {
            Console.WriteLine("Lower, try a higher one.");
        }
        else if (guess > magicNumber)
        {
            Console.WriteLine("Oh, this is Higher.");
        }
        else
        {
            Console.WriteLine("You guessed it!");
        }
    }
}
