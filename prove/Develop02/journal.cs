using System;
using System.IO;

class Journal 
{
List<entry> entries = new List<entry>();

public Journal()
{

}
public void Display()
{
    foreach(var e in entries)
    {
        Console.WriteLine($"\nDate: {e.dateText} - Prompt: {e.prompt}");
        Console.WriteLine(e.answer);
    }
} 
public void CreateJournalEntry(entry newEntry)
{
entries.Add(newEntry); 
}
public void SaveToCSV()
{
Console.WriteLine("What do you want to name your file? ");
string fileName = Console.ReadLine();
if (File.Exists(fileName))
{
    Console.WriteLine("It exist.s");
    LoadFromCSV(fileName);
    using(var appendText = new StreamWriter ("./"+fileName,  append: true)){
            foreach(var e in entries)
    {
        appendText.WriteLine($"\nDate: {e.dateText} - Prompt: {e.prompt}");
        appendText.WriteLine(e.answer);
    }
    }

}
using(var newFile = new StreamWriter(fileName)){
    foreach(var e in entries)
    {
        newFile.WriteLine($"\nDate: {e.dateText} - Prompt: {e.prompt}");
        newFile.WriteLine(e.answer);
    }
}

}
public void LoadFromCSV(string journalName)
{
     string [] lines = System.IO.File.ReadAllLines(journalName);
     var entryPieces = new List<string>();
     foreach (string line in lines)
     {
        if(line.Length !=0){
            if(entryPieces.Count == 2){
                var newEntry = new entry(entryPieces[0], entryPieces[1]);
                entries.Add(newEntry);
                entryPieces.Clear();
            
            }
            entryPieces.Add(line);
        }
     }
}
}