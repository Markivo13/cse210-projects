using System;
using System.Collections.Generic;
using System.IO;

// Represents a Goal
public abstract class Goal
{
    public string Title { get; }
    public int Value { get; }
    public bool IsCompleted { get; set; }

    public Goal(string title, int value)
    {
        Title = title;
        Value = value;
    }

    public abstract void Accomplish();

    public override string ToString()
    {
        string completedStatus = IsCompleted ? "[X]" : "[ ]";
        return $"{completedStatus} {Title}";
    }
}