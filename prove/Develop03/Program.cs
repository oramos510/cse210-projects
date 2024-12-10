using System;
class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", "3", "5", "6");
        string scriptureText = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";
        Scripture scripture = new Scripture(reference, scriptureText);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("\nAll words are hidden. Great job!");
                break;
            }

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine()?.ToLower();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
        }
    }
}