public class SimpleGoal : Goal
{
    private bool isComplete = false;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) {}

    public override int RecordEvent()
    {
        if (!isComplete)
        {
            isComplete = true;
            return points;
        }
        return 0;
    }

    public override bool IsComplete() => isComplete;

    public override string GetStatus() => $"[{(isComplete ? "X" : " ")}] {name}";

    public override string Serialize() =>
        $"SimpleGoal|{name}|{description}|{points}|{isComplete}";
}
