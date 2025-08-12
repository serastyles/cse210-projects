
public class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int totalScore = 0;

    public void AddGoal(Goal goal) => goals.Add(goal);

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            int earned = goals[goalIndex].RecordEvent();
            totalScore += earned;
            Console.WriteLine($"You earned {earned} points!");
        }
    }

    public void ShowGoals()
    {
        for (int i = 0; i < goals.Count; i++)
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
    }

    public void ShowScore() => Console.WriteLine($"Total Score: {totalScore}");

    public void SaveToFile(string filename)
    {
        var lines = new List<string> { totalScore.ToString() };
        lines.AddRange(goals.Select(g => g.Serialize()));
        File.WriteAllLines(filename, lines);
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename)) return;

        var lines = File.ReadAllLines(filename);
        totalScore = int.Parse(lines[0]);
        goals.Clear();

        foreach (var line in lines.Skip(1))
        {
            var parts = line.Split('|');
            switch (parts[0])
            {
                case "SimpleGoal":
                    var sg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    if (bool.Parse(parts[4]))
                    {
                        sg.RecordEvent();
                    }
                    goals.Add(sg);
                    break;

                case "EternalGoal":
                    goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    var checklist = new ChecklistGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        int.Parse(parts[6]),
                        int.Parse(parts[5]),
                        int.Parse(parts[7])
                        );
                    goals.Add(checklist);
                    break;
            }
        }
    }
}
