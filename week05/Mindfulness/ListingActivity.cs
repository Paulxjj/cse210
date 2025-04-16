using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private static int _count = 0; // Static counter to track how many times this activity is performed

    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    public override void Run()
    {
        _count++; // Increment the counter
        DisplayStartingMessage();
        Console.Write("Enter the duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        ShowCountDown(5);

        List<string> responses = GetListFromUser(duration);
        Console.WriteLine($"You listed {responses.Count} items.");

        DisplayEndingMessage(duration);
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }

    private List<string> GetListFromUser(int duration)
    {
        List<string> responses = new List<string>();
        Console.WriteLine("Start listing items:");
        int elapsed = 0;

        while (elapsed < duration)
        {
            if (Console.KeyAvailable)
            {
                string response = Console.ReadLine();
                responses.Add(response);
            }
            Thread.Sleep(1000);
            elapsed++;
        }

        return responses;
    }

    public static int GetCount()
    {
        return _count;
    }
}