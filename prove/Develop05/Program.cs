using System;
using System.Threading;

public class Activity
{
    protected int duration;

    public void SetDuration()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        duration = int.Parse(Console.ReadLine());
    }

    public void ShowPause(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void StartActivity(string activityName, string description)
    {
        Console.Clear();
        Console.WriteLine($"{activityName} Activity\n");
        Console.WriteLine($"{description}\n");
        SetDuration();
        Console.WriteLine("Prepare to begin...");
        ShowPause(3);
    }

    public void EndActivity(string activityName)
    {
        Console.Clear();
        Console.WriteLine($"Great job! You completed the {activityName} activity.");
        Console.WriteLine($"You spent {duration} seconds on this activity.");
        ShowPause(3);
    }
}
public class BreathingActivity : Activity
{
    public void ExecuteBreathing()
    {
        StartActivity("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            ShowPause(4);
            Console.WriteLine("Breathe out...");
            ShowPause(4);
        }

        EndActivity("Breathing");
    }
}
public class ReflectionActivity : Activity
{
    private static string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?"
    };

    public void ExecuteReflection()
    {
        StartActivity("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience.");

        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(randomPrompt);
        ShowPause(3);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            string randomQuestion = questions[random.Next(questions.Length)];
            Console.WriteLine(randomQuestion);
            ShowPause(5);
        }

        EndActivity("Reflection");
    }
}
public class ListingActivity : Activity
{
    private static string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?"
    };

    public void ExecuteListing()
    {
        StartActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(randomPrompt);
        ShowPause(3);

        Console.WriteLine("Start listing...");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            string input = Console.ReadLine();
            count++;
        }

        Console.WriteLine($"You listed {count} items.");
        EndActivity("Listing");
    }
}
public class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Select an activity (1-4): ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.ExecuteBreathing();
                    break;
                case 2:
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.ExecuteReflection();
                    break;
                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.ExecuteListing();
                    break;
                case 4:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }
}