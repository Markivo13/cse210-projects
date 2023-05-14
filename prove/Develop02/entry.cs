class entry
{
    
    public string dateText;
    public string prompt;
    public string answer;
    public entry(string myPrompt, string myAnswer)
    {
    DateTime theCurrentTime = DateTime.Now;
    dateText = theCurrentTime.ToShortDateString();
    prompt = myPrompt; 
    answer = myAnswer;
    }
    // public void DisplayEntry()
    // {

    // }
    // public string getEntryAsCSV()
    // {
    //     return string.Format("{0}{1}{2}", dateText, prompt, answer);
    // }
}