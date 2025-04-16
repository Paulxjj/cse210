using System;
using System.Collections.Generic;

class ReflectingActivity : Activity
{
    private static int _count = 0; // Static counter to track how many times this activity is performed

    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") { }

    public override void Run()
    {
        _count++; // Increment the counter
        DisplayStartingMessage();
        Console.Write("Enter the duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        DisplayPrompt();
        DisplayQuestions(duration);

        DisplayEndingMessage(duration);
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        return _questions[random.Next(_questions.Count)];
    }

    private void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        ShowSpinner(3);
    }

    private void DisplayQuestions(int duration)
    {
        int elapsed = 0;

        while (elapsed < duration)
        {
            string question = GetRandomQuestion();
            Console.WriteLine(question);
            ShowSpinner(3);
            elapsed += 3;
        }
    }

    public static int GetCount()
    {
        return _count;
    }
}