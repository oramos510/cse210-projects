public class Reference
{
    public string Book { get; private set; }
    public string Chapter { get; private set; }
    public string VerseRange { get; private set; }
    public Reference(string book, string chapter, string verse)
    {
        Book = book;
        Chapter = chapter;
        VerseRange = verse;
    }
    public Reference(string book, string chapter, string startVerse, string endVerse)
    {
        Book = book;
        Chapter = chapter;
        VerseRange = $"{startVerse}-{endVerse}";
    }
    public override string ToString()
    {
        return $"{Book} {Chapter}:{VerseRange}";
    }
}