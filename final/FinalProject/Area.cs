using System;
using System.Collections.Generic;

// Abstract class representing an area in the house
public abstract class Area
{
    public string Name { get; }

    protected List<string> items;

    public Area(string name)
    {
        Name = name;
        items = new List<string>();
    }

    public virtual void AddItem(string item)
    {
        items.Add(item);
        Console.WriteLine($"Item '{item}' added to {Name}.");
    }

    public virtual void DisplayItems()
    {
        Console.WriteLine($"Items in {Name}:");
        foreach (string item in items)
        {
            Console.WriteLine(item);
        }
    }

    public virtual bool SearchItem(string item)
    {
        return items.Contains(item);
    }

    public virtual bool RetrieveItem(string item)
    {
        if (items.Remove(item))
        {
            Console.WriteLine($"Item '{item}' retrieved from {Name}.");
            return true;
        }
        return false;
    }
}