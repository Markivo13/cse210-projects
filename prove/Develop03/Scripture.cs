using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference reference;
    private string text;
    private List<bool> hiddenWords;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        this.text = text;
        hiddenWords = Enumerable.Repeat(false, GetWordCount()).ToList();
    }

    public Reference GetReference()
    {
        return reference;
    }

    public string GetText()
    {
        return text;
    }

    public int GetWordCount()
    {
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    public Word GetWordAtPosition(int position)
    {
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (position < 0 || position >= words.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Invalid word position");
        }

        return new Word(words[position]);
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, GetWordCount() / 2); // Hide 1 to half of the words

        for (int i = 0; i < wordsToHide; i++)
        {
            int wordIndex = GetRandomHiddenWordIndex(random);
            hiddenWords[wordIndex] = true;
        }
    }

    public bool AreAllWordsHidden()
    {
        return hiddenWords.All(word => word);
    }

    public void ClearHiddenWords()
    {
        hiddenWords = Enumerable.Repeat(false, GetWordCount()).ToList();
    }

    public string GetVisibleText()
    {
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        List<string> visibleWords = new List<string>();
        for (int i = 0; i < words.Length; i++)
        {
            if (hiddenWords[i])
            {
                visibleWords.Add("_".PadRight(words[i].Length, '_'));
            }
            else
            {
                visibleWords.Add(words[i]);
            }
        }

        return string.Join(" ", visibleWords);
    
    }

    private int GetRandomHiddenWordIndex(Random random)
    {
        List<int> hiddenIndices = new List<int>();
        for (int i = 0; i < hiddenWords.Count; i++)
        {
            if (!hiddenWords[i])
            {
                hiddenIndices.Add(i);
            }
        }

        if (hiddenIndices.Count == 0)
        {
            throw new InvalidOperationException("All words are already hidden");
        }

        int randomIndex = random.Next(0, hiddenIndices.Count);
        return hiddenIndices[randomIndex];
    }
}
