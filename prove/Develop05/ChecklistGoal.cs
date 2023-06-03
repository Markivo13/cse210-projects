// Represents a Checklist Goal
public class ChecklistGoal : Goal
{
    private int _completedCount;
    private int _targetCount;
    public int BonusValue { get; }

    public ChecklistGoal(string title, int value, int targetCount, int bonusValue) : base(title, value)
    {
        _targetCount = targetCount;
        BonusValue = bonusValue;
    }

    public override void Accomplish()
    {
        if (!IsCompleted)
        {
            _completedCount++;
            Console.WriteLine($"You accomplished a step for the checklist goal: {Title} (+{Value} points)");

            if (_completedCount == _targetCount)
            {
                Console.WriteLine($"Congratulations! You completed the checklist goal: {Title} (+{BonusValue} bonus points)");
                IsCompleted = true;
            }
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()} - Completed {_completedCount}/{_targetCount} times";
    }
}