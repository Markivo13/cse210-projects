// Represents the entry point of the program
public class Program
{
    public static void Main(string[] args)
    {
        string filePath = "goals.txt";
        EternalQuestProgram program = new EternalQuestProgram(filePath);
        program.Run();
    }
}