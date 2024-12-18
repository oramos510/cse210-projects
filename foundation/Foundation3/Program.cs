using System;
using System.Collections.Generic;

public abstract class Activity
{
    public string Date { get; set; }
    public int Minutes { get; set; }

    public Activity(string date, int minutes)
    {
        Date = date;
        Minutes = minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

public string GetSummary()
{
    string distanceUnit = this is Swimming ? "km" : "mile";
    
    string paceUnit = distanceUnit == "mile" ? "min per mile" : "min per km";

    return $"{Date} {this.GetType().Name} ({Minutes} min) - Distance {GetDistance():0.0} {distanceUnit}, Speed {GetSpeed():0.0} {distanceUnit}/hr, Pace: {GetPace():0.0} {paceUnit}";
}
}

public class Running : Activity
{
    public double Distance { get; set; }

    public Running(string date, int minutes, double distance)
        : base(date, minutes)
    {
        Distance = distance;
    }

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetSpeed()
    {
        return (Distance / Minutes) * 60;
    }

    public override double GetPace()
    {
        return (double)Minutes / Distance;
    }
}

public class Cycling : Activity
{
    public double Speed { get; set; }
    public Cycling(string date, int minutes, double speed)
        : base(date, minutes)
    {
        Speed = speed;
    }

    public override double GetDistance()
    {
        return (Speed * Minutes) / 60;
    }
    public override double GetSpeed()
    {
        return Speed;
    }

    public override double GetPace()
    {
        return 60 / Speed;
    }
}
public class Swimming : Activity
{
    public int Laps { get; set; }

    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * 50 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60;
    }

    public override double GetPace()
    {
        return (double)Minutes / GetDistance();
}

class Program
{
    static void Main()
    {
        var activities = new List<Activity>
        {
            new Running("03 Nov 2022", 30, 3.0),
            new Cycling("03 Nov 2022", 30, 12.0),
            new Swimming("03 Nov 2022", 30, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
}