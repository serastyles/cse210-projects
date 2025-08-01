// Added a meditative pause between cycles 
// Added a 2 seconds interval for one to pull enough air before the next breath in.
public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    public override void Run()
    {
        Start();
        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.Write("...");
            Thread.Sleep(2000);
            Console.WriteLine("\nBreathe in...");
            Countdown(6);
            elapsed += 4;

            if (elapsed >= _duration) break;
            Console.WriteLine("Breathe out...");
            Countdown(2);
            elapsed += 4;

            }
            End();
        }
    }
