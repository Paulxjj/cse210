using System;

class BreathingActivity : Activity
{
    private static int _count = 0; // Static counter to track how many times this activity is performed

    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    public override void Run()
    {
        _count++; // Increment the counter
        DisplayStartingMessage();
        Console.Write("How long, in seconds, would you like for your session? ");
        int duration = int.Parse(Console.ReadLine());

        int elapsed = 0;
        while (elapsed < duration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(3);
            Console.WriteLine("Now breathe out...");
            ShowCountDown(3);
            elapsed += 6;
        }

        DisplayEndingMessage(duration);
    }

    public static int GetCount()
    {
        return _count;
    }
}