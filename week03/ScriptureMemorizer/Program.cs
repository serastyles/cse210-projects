using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // 🔹 Load scriptures from a file
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");

        Console.WriteLine("Scripture Memorization Tool\n");
        Console.WriteLine("1. Load a random scripture from file");
        Console.WriteLine("2. Enter your own scripture");
        Console.WriteLine("3. Exit");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        Scripture scripture = null;

        if (choice == "1" && scriptures.Count > 0)
        {
            // 🔹 Pick a random scripture from the file
            var rand = new Random();
            scripture = scriptures[rand.Next(scriptures.Count)];
        }
        else if (choice == "2")
        {
            // 🔹 Let the user type their own scripture
            scripture = GetUserScripture();
        }
        else
        {
            Console.WriteLine("Goodbye!");
            return;
        }

        // 🔹 Start the word hiding session
        RunMemorizationLoop(scripture);
    }

    // 🔹 NEW: Load scriptures from a file
    static List<Scripture> LoadScripturesFromFile(string filename)
    {
        var scriptures = new List<Scripture>();
        if (!File.Exists(filename))
        {
            Console.WriteLine($"Scripture file not found: {filename}");
            return scriptures;
        }

        var lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length != 2) continue;

            Reference reference = Reference.Parse(parts[0].Trim()); // 🔹 Parse string into Reference object
            string text = parts[1].Trim();
            scriptures.Add(new Scripture(reference, text));
        }
        return scriptures;
    }

    // 🔹 NEW: Let the user input their own scripture
    static Scripture GetUserScripture()
    {
        Console.Write("Enter book (e.g. John): ");
        string book = Console.ReadLine();

        Console.Write("Enter chapter: ");
        int chapter = int.Parse(Console.ReadLine());

        Console.Write("Enter start verse: ");
        int startVerse = int.Parse(Console.ReadLine());

        Console.Write("Enter end verse (same as start if single verse): ");
        int endVerse = int.Parse(Console.ReadLine());

        Console.Write("Enter scripture text: ");
        string text = Console.ReadLine();

        Reference reference = new Reference(book, chapter, startVerse, endVerse);
        return new Scripture(reference, text);
    }

    // 🔹 Keeps asking user to press Enter or 'quit' and hides words
    static void RunMemorizationLoop(Scripture scripture)
    {
        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // hide 3 words at a time
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are now hidden. Press Enter to exit.");
        Console.ReadLine();
    }
}
