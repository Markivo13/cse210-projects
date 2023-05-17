public class Reference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;

    public Reference(string book, int chapter, int startVerse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = startVerse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    public string GetBook()
    {
        return book;
    }

    public int GetChapter()
    {
        return chapter;
    }

    public int GetStartVerse()
    {
        return startVerse;
    }

    public int GetEndVerse()
    {
        return endVerse;
    }

    public bool IsSingleVerse()
    {
        return startVerse == endVerse;
    }

    public override string ToString()
    {
        if (IsSingleVerse())
        {
            return $"{book} {chapter}:{startVerse}";
        }
        else
        {
            return $"{book} {chapter}:{startVerse}-{endVerse}";
        }
    }
}
