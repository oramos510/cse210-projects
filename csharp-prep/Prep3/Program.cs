using System;

class Program
{    static void Main()
    {
        string playAgain = "yes";
        
        while (playAgain.ToLower() == "yes")
        {
            Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

            int userGuess;
            int guessCount = 0;

            do
            {
                Console.Write("What is your guess? ");
                userGuess = int.Parse(Console.ReadLine());
                guessCount++;

                if (userGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (userGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }

            } while (userGuess != magicNumber);

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }
        Console.WriteLine("Thanks for playing!");
    }
}