public class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonusPoints;
    private int totalPointsEarned;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int currentCount = 0, int totalPointsEarned = 0)
        : base(name, description, points)
    {
        this.targetCount = targetCount;
        this.bonusPoints = bonusPoints;
        this.currentCount = currentCount;
        this.totalPointsEarned = totalPointsEarned;
    }

    public override int RecordEvent()
    {
        if (currentCount < targetCount)
        {
            currentCount++;
            int earned = points;

            if (IsComplete())
            {
                earned += bonusPoints;
                Console.WriteLine($"\n Congratulations! You completed the goals \"{name}\" and earned a bonus of {bonusPoints} points!");
            }
            totalPointsEarned += earned;
            return earned;
        }
        else
        {
            Console.WriteLine($"Goal \" {name}\" is already complete!");
            return 0;
        }
        
    }

    public override bool IsComplete() => currentCount >= targetCount;

    public override string GetStatus() =>
        $"[{(IsComplete() ? "X" : " ")}] {name} — Completed {currentCount}/{targetCount} times (points so far: {totalPointsEarned})";

    public override string Serialize() =>
        $"ChecklistGoal|{name}|{description}|{points}|{targetCount}|{currentCount}|{bonusPoints}|{totalPointsEarned}";
}
