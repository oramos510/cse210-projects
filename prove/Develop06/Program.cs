using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EternalQuest
{
    abstract class Goal
    {
        public string Name { get; set; }
        public int Points { get; protected set; }
        public bool IsComplete { get; set; }

        public Goal(string name)
        {
            Name = name;
            IsComplete = false;
        }

        public abstract void RecordEvent();
        public abstract string GetGoalDetails();
    }

    class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int points) : base(name)
        {
            Points = points;
        }

        public override void RecordEvent()
        {
            if (!IsComplete)
            {
                IsComplete = true;
                Console.WriteLine($"You have completed {Name} and earned {Points} points!");
            }
            else
            {
                Console.WriteLine($"{Name} has already been completed.");
            }
        }

        public override string GetGoalDetails()
        {
            return IsComplete ? $"[X] {Name}: {Points} points" : $"[ ] {Name}: {Points} points";
        }
    }

    class EternalGoal : Goal
    {
        public EternalGoal(string name, int points) : base(name)
        {
            Points = points;
        }

        public override void RecordEvent()
        {
            Points += 100;
            Console.WriteLine($"You have completed {Name} and earned 100 bonus points!");
        }

        public override string GetGoalDetails()
        {
            return $"[ ] {Name}: {Points} points";
        }
    }

    class ChecklistGoal : Goal
    {
        public int TimesToComplete { get; set; }
        public int TimesCompleted { get; set; }
        public int BonusPoints { get; set; }

        public ChecklistGoal(string name, int timesToComplete, int pointsPerCompletion, int bonusPoints) : base(name)
        {
            TimesToComplete = timesToComplete;
            Points = pointsPerCompletion;
            BonusPoints = bonusPoints;
            TimesCompleted = 0;
        }

        public override void RecordEvent()
        {
            if (TimesCompleted < TimesToComplete)
            {
                TimesCompleted++;
                Console.WriteLine($"You completed {Name} for the {TimesCompleted} time, earning {Points} points!");
            }

            if (TimesCompleted == TimesToComplete)
            {
                Points += BonusPoints;
                Console.WriteLine($"Bonus! You've completed {Name} {TimesToComplete} times and earned {BonusPoints} bonus points!");
            }
        }

        public override string GetGoalDetails()
        {
            return TimesCompleted < TimesToComplete ? $"[ ] {Name}: {TimesCompleted}/{TimesToComplete} completed" : $"[X] {Name}: {TimesCompleted}/{TimesToComplete} completed, Bonus earned!";
        }
    }

    class GoalTracker
    {
        public List<Goal> Goals { get; set; } = new List<Goal>();
        public int TotalPoints { get; set; } = 0;

        public void AddGoal(Goal goal)
        {
            Goals.Add(goal);
        }

        public void RecordGoalEvent(string goalName)
        {
            var goal = Goals.FirstOrDefault(g => g.Name == goalName);
            if (goal != null)
            {
                goal.RecordEvent();
                TotalPoints += goal.Points;
            }
            else
            {
                Console.WriteLine($"Goal {goalName} not found.");
            }
        }

        public void DisplayGoals()
        {
            foreach (var goal in Goals)
            {
                Console.WriteLine(goal.GetGoalDetails());
            }
        }

        public void SaveGoals(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var goal in Goals)
{
    if (goal is ChecklistGoal checklistGoal)
    {
        writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Points},{checklistGoal.TimesCompleted},{checklistGoal.TimesToComplete}");
    }
    else
    {
        writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Points},0,0");
    }
}

            }
        }

        public void LoadGoals(string fileName)
        {
            if (File.Exists(fileName))
            {
                var lines = File.ReadAllLines(fileName);
                foreach (var line in lines)
                {
                    var parts = line.Split(",");
                    var type = parts[0];
                    var name = parts[1];
                    var points = int.Parse(parts[2]);
                    var timesCompleted = int.Parse(parts[3]);
                    var timesToComplete = int.Parse(parts[4]);

                    Goal goal = type switch
                    {
                        "SimpleGoal" => new SimpleGoal(name, points),
                        "EternalGoal" => new EternalGoal(name, points),
                        "ChecklistGoal" => new ChecklistGoal(name, timesToComplete, points, 500),
                        _ => throw new Exception("Unknown goal type")
                    };

                    if (goal is ChecklistGoal checklistGoal)
                    {
                        checklistGoal.TimesCompleted = timesCompleted;
                    }

                    Goals.Add(goal);
                }
            }
            else
            {
                Console.WriteLine("No saved goals found.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GoalTracker goalTracker = new GoalTracker();

            goalTracker.AddGoal(new SimpleGoal("Run a marathon", 1000));
            goalTracker.AddGoal(new EternalGoal("Read Scriptures", 100));
            goalTracker.AddGoal(new ChecklistGoal("Attend the temple", 50, 10, 500));

            goalTracker.DisplayGoals();

            goalTracker.RecordGoalEvent("Read Scriptures");
            goalTracker.RecordGoalEvent("Attend the temple");

            goalTracker.DisplayGoals();

            goalTracker.SaveGoals("goals.txt");
            goalTracker.LoadGoals("goals.txt");

            Console.WriteLine($"Total Points: {goalTracker.TotalPoints}");
        }
    }
}