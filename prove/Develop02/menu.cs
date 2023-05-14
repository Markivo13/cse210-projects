public class Menu{
    Journal notebook = new Journal();
    public void Display(){
        string response = ";";
        while (response != "5")
        {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.WriteLine("What would you like to do? ");
        string choice = Console.ReadLine();

        switch(choice)
        {
        case "1":
        random_question question = new random_question();
        string q = question.random_Question();
        Console.WriteLine(q);
        Console.WriteLine("Your answer");
        string answer = Console.ReadLine();
        entry newEntry = new entry(q, answer);
        notebook.CreateJournalEntry(newEntry);
        break;

        case "2":
        notebook.Display();

        break;

        case "3":
        Console.WriteLine("What file do you want to load? ");
        string saveFile = Console.ReadLine();
        
        notebook.LoadFromCSV(saveFile);
        break;

        case "4":
        notebook.SaveToCSV();
        break;
        
        case "5":
        System.Environment.Exit(1);
        break;
        }
        }
    }
}