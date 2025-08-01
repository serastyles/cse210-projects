// ------------------------
// Activity.cs (Base Class)
// ------------------------
using System;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected void Spinner(int seconds)
    {
        string[] spinner = {"|", "/", "-", "\\"};
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
            i++;
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + "...");
            Thread.Sleep(1000);
            Console.Write("\b\b\b\b");
        }
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Starting the {_name} Activity.");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Spinner(4);
    }

    public void End()
    {
        Console.WriteLine("\nWell done!");
        Spinner(2);
        Console.WriteLine($"You completed the {_name} activity for {_duration} seconds.");
        Spinner(2);
    }

    public abstract void Run();
}
