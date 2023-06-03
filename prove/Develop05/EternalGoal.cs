// Represents an Eternal Goal
public class EternalGoal : Goal
{
    public EternalGoal(string title, int value) : base(title, value)
    {
    }

    public override void Accomplish()
    {
        Console.WriteLine($"You accomplished the goal: {Title} (+{Value} points)");
    }
}