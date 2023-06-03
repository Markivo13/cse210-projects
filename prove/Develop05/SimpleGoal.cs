// Represents a Simple Goal
public class SimpleGoal : Goal
{
    public string Description { get; }

    public SimpleGoal(string title, string description, int value) : base(title, value)
    {
        Description = description;
    }

    public override void Accomplish()
    {
        Console.WriteLine($"You accomplished the goal: {Title} (+{Value} points)");
        IsCompleted = true;
    }

    public override string ToString()
    {
        string completedStatus = IsCompleted ? "[X]" : "[ ]";
        return $"{completedStatus} {Title} - {Description}";
    }
}
