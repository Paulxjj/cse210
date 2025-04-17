using System;
using System.Collections.Generic;
using ExerciseTracking.Models;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 4, 17), 30, 3.0),
            new Cycling(new DateTime(2025, 4, 17), 45, 15.0),
            new Swimming(new DateTime(2025, 4, 17), 20, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}