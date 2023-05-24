using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Goal
{
    public string Description { get; set; }
    public GoalType Type { get; set; }
    public int Value { get; set; }
    public int CurrentCount { get; set; }
    public int CompletionCount { get; set; }
    public bool IsCompleted => Type == GoalType.SimpleGoal || (Type == GoalType.ChecklistGoal && CurrentCount >= CompletionCount);

    public Goal(string description, GoalType type, int value, int completionCount = 0)
    {
        Description = description;
        Type = type;
        Value = value;
        CompletionCount = completionCount;
    }

    public string GetStatusString()
    {
        if (Type == GoalType.SimpleGoal)
            return IsCompleted ? "[X]" : "[ ]";
        else if (Type == GoalType.EternalGoal)
            return "[X]";
        else
            return $"Completed {CurrentCount}/{CompletionCount} times";
    }
}