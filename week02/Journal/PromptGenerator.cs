using System;
using System.Collections.Generic;

class PromptGenerator
{
    private List<string> prompts = new List<string>
    {
        "What made you smile today?",
        "What is one thing you learned today?",
        "Describe a moment you felt proud of yourself recently.",
        "What is something you are grateful for today?",
        "What is a challenge you faced today and how did you overcome it?",
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        return prompts[random.Next(prompts.Count)];
    }
}