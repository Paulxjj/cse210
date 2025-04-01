using System;

class Entry
{
    public string Date { get; private set; }
    public string Time { get; private set; }
    public string Prompt { get; private set; }
    public string Response { get; private set; }
    public string Mood { get; private set; }
    public string Tag { get; private set; }

    public Entry(string prompt, string response, string mood, string tag)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Time = DateTime.Now.ToString("HH:mm:ss");
        Prompt = prompt;
        Response = response;
        Mood = mood;
        Tag = tag;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Time: {Time}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine($"Tag: {Tag}");
        Console.WriteLine();
    }

    public string ToFileFormat()
    {
        return $"{Date}|{Time}|{Prompt}|{Response}|{Mood}|{Tag}";
    }

    public static Entry FromFileFormat(string fileLine)
    {
        string[] parts = fileLine.Split('|');
        return new Entry(parts[2], parts[3], parts[4], parts[5])
        {
            Date = parts[0],
            Time = parts[1]
        };
    }
}