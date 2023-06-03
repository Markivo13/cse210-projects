// Represents the Eternal Quest program
public class EternalQuestProgram
{
    private List<Goal> _goals;
    private string _filePath;
    private int _totalScore;

    public EternalQuestProgram(string filePath)
    {
        _goals = new List<Goal>();
        _filePath = filePath;
        _totalScore = 0;
    }

    public void Run()
    {
        LoadGoals();

        bool quit = false;
        while (!quit)
        {
            ShowMainMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private void ShowMainMenu()
    {
        Console.WriteLine("Main Menu:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit");
        Console.Write("Enter your choice: ");
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter the goal type: ");
        string goalType = Console.ReadLine();

        Console.Write("Enter the goal title: ");
        string title = Console.ReadLine();

        Console.Write("Enter the goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the goal value: ");
        int value = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case "1":
                _goals.Add(new SimpleGoal(title, description, value));
                break;
            case "2":
                _goals.Add(new EternalGoal(title, value));
                break;
            case "3":
                Console.Write("Enter the target count for the checklist goal: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter the bonus value for the checklist goal: ");
                int bonusValue = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(title, value, targetCount, bonusValue));
                break;
            default:
                Console.WriteLine("Invalid goal type. Please try again.");
                break;
        }
    }

    private void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
        }
        else
        {
            Console.WriteLine("\nGoals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i]}");
            }
        }
    }

    private void SaveGoals()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (Goal goal in _goals)
                {
                    string goalType = goal.GetType().Name;
                    string title = goal.Title;
                    int value = goal.Value;
                    bool isCompleted = goal.IsCompleted;

                    writer.WriteLine($"{goalType},{title},{value},{isCompleted}");
                }
            }
            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to save goals: {ex.Message}");
        }
    }

    private void LoadGoals()
    {
        _goals.Clear();

        if (File.Exists(_filePath))
        {
            try
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        string goalType = parts[0];
                        string title = parts[1];
                        int value = int.Parse(parts[2]);
                        bool isCompleted = bool.Parse(parts[3]);

                        Goal goal;
                        switch (goalType)
                        {
                            case "SimpleGoal":
                                goal = new SimpleGoal(title, "", value);
                                break;
                            case "EternalGoal":
                                goal = new EternalGoal(title, value);
                                break;
                            case "ChecklistGoal":
                                int targetCount = value;
                                int bonusValue = int.Parse(parts[4]);
                                goal = new ChecklistGoal(title, value, targetCount, bonusValue);
                                break;
                            default:
                                throw new InvalidOperationException("Invalid goal type found while loading goals.");
                        }

                        goal.IsCompleted = isCompleted;
                        _goals.Add(goal);
                    }
                }
                Console.WriteLine("Goals loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load goals: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }

    private void RecordEvent()
    {
        Console.WriteLine("\nRecorded Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i]}");
        }

        Console.Write("Enter the goal number to record: ");
        int goalNumber = int.Parse(Console.ReadLine());

        if (goalNumber >= 1 && goalNumber <= _goals.Count)
        {
            Goal goal = _goals[goalNumber - 1];
            if (!goal.IsCompleted)
            {
                goal.Accomplish();
                _totalScore += goal.Value;
                Console.WriteLine($"Total Score: {_totalScore}");
            }
            else
            {
                Console.WriteLine("Goal already completed.");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }
}
