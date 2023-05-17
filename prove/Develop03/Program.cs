public class Program
{
    private static List<Scripture> scriptures;

    public static void Main()
    {
        InScriptures();
        RunProgram();
    }

    private static void InScriptures()
{
    scriptures = new List<Scripture>();

    // Example: Add some scriptures
    Reference reference1 = new Reference("John", 3, 16);
    string text1 = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
    string randomVerse1 = GetRandomVerseFromText(text1);
    scriptures.Add(new Scripture(reference1, randomVerse1));

    Reference reference2 = new Reference("Proverbs", 3, 5, 6);
    string text2 = "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.";
    string randomVerse2 = GetRandomVerseFromText(text2);
    scriptures.Add(new Scripture(reference2, randomVerse2));

    // Add more scriptures as needed
}

private static string GetRandomVerseFromText(string text)
{
    string[] verses = text.Split(';', StringSplitOptions.RemoveEmptyEntries);

    if (verses.Length == 0)
    {
        throw new InvalidOperationException("No verses found in the scripture text");
    }

    Random random = new Random();
    int randomIndex = random.Next(0, verses.Length);

    return verses[randomIndex].Trim();
}
    private static void RunProgram()
    {
        Random random = new Random();
        int scriptureIndex = random.Next(0, scriptures.Count);
        Scripture currentScripture = scriptures[scriptureIndex];

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Scripture Reference: " + currentScripture.GetReference());
            Console.WriteLine("Scripture Text: " + currentScripture.GetVisibleText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to reveal more words or type 'quit' to exit.");

            string input = Console.ReadLine().Trim();

            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            currentScripture.HideRandomWords();

            if (currentScripture.AreAllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine("All words in the scripture are hidden. Program will exit.");
                return;
            }
        }
    }
}