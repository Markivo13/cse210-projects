class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main()
    {
        LoadGoals();

        int choice;
        do
        {
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Enter your choice: ");
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
                Console.Write("Enter your choice: ");
            }

            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    CreateNewGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    Console.WriteLine("Thank you for using the goal tracker. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }

            Console.WriteLine();
        } while (choice != 6);
    }

    static void CreateNewGoal()
    {
        Console.WriteLine("Goal types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        int goalType;
        Console.Write("Enter the goal type: ");
        while (!int.TryParse(Console.ReadLine(), out goalType) || goalType < 1 || goalType > 3)
        {
            Console.WriteLine("Invalid goal type. Please enter a number between 1 and 3.");
            Console.Write("Enter the goal type: ");
        }

        Console.Write("Enter the goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the value for this goal: ");
        int value;
        while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
        {
            Console.WriteLine("Invalid value. Please enter a positive integer.");
            Console.Write("Enter the value for this goal: ");
        }

        int completionCount = 0;
        if (goalType == 3)
        {
            Console.Write("Enter the completion count for this checklist goal: ");
            while (!int.TryParse(Console.ReadLine(), out completionCount) || completionCount <= 0)
            {
                Console.WriteLine("Invalid completion count. Please enter a positive integer.");
                Console.Write("Enter the completion count for this checklist goal: ");
            }
        }

        GoalType type = (GoalType)(goalType - 1);
        Goal goal = new Goal(description, type, value, completionCount);
        goals.Add(goal);

        Console.WriteLine("Goal created successfully!");
    }

    static void ListGoals()
    {
        Console.WriteLine("Goals:");

        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            Console.WriteLine($"{i + 1}. {goal.GetStatusString()} {goal.Description}");
        }

        Console.WriteLine("Score: " + score);
    }

    static void SaveGoals()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                foreach (Goal goal in goals)
                {
                    writer.WriteLine($"{goal.Description},{goal.Type},{goal.Value},{goal.CurrentCount},{goal.CompletionCount}");
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while saving goals: " + ex.Message);
        }
    }

    static void LoadGoals()
    {
        try
        {
            if (File.Exists("goals.txt"))
            {
                goals.Clear();

                using (StreamReader reader = new StreamReader("goals.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length >= 4)
                        {
                            string description = parts[0];
                            GoalType type = (GoalType)Enum.Parse(typeof(GoalType), parts[1]);
                            int value = int.Parse(parts[2]);
                            int currentCount = int.Parse(parts[3]);

                            int completionCount = 0;
                            if (type == GoalType.ChecklistGoal && parts.Length >= 5)
                                completionCount = int.Parse(parts[4]);

                            Goal goal = new Goal(description, type, value, completionCount);
                            goal.CurrentCount = currentCount;
                            goals.Add(goal);
                        }
                    }
                }

                Console.WriteLine("Goals loaded successfully!");
            }
            else
            {
                Console.WriteLine("No saved goals found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while loading goals: " + ex.Message);
        }
    }

    static void RecordEvent()
    {
        Console.Write("Enter the index of the goal you accomplished: ");
        int index;
        while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > goals.Count)
        {
            Console.WriteLine("Invalid goal index. Please enter a number between 1 and " + goals.Count + ".");
            Console.Write("Enter the index of the goal you accomplished: ");
        }

        Goal goal = goals[index - 1];

        if (goal.Type == GoalType.SimpleGoal || goal.Type == GoalType.ChecklistGoal)
        {
            score += goal.Value;
            goal.CurrentCount++;
            Console.WriteLine("Event recorded successfully!");
        }
        else if (goal.Type == GoalType.EternalGoal)
        {
            score += goal.Value;
            Console.WriteLine("Event recorded successfully!");
        }
    }
}