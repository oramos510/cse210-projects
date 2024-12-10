using System;
using System.Collections.Generic;
using System.Linq;
public class Scripture
{
    private Reference Reference { get; }
    private List<Word> Words { get; }
    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }
    public void HideRandomWords(int count = 3)
    {
        var visibleWords = Words.Where(word => !word.IsHidden).ToList();
        var random = new Random();

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }
    public bool AllWordsHidden()
    {
        return Words.All(word => word.IsHidden);
    }
    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", Words.Select(word => word.GetDisplayText()));
        return $"{Reference}\n{scriptureText}";
    }
}