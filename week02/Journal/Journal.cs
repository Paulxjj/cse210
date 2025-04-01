using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        entries.Add(newEntry);
        Console.WriteLine("Your entry has been added!");
    }

    public void DisplayAll()
    {
        if (entries.Count > 0)
        {
            Console.WriteLine("\nJournal Entries:");
            foreach (Entry entry in entries)
            {
                entry.Display();
            }
        }
        else
        {
            Console.WriteLine("\nNo entries found. Start by writing a new entry!");
        }
    }

    public void SaveToFile(string fileName)
    {
        try
        {
            List<string> lines = new List<string>();
            foreach (Entry entry in entries)
            {
                lines.Add(entry.ToFileFormat());
            }

            File.WriteAllLines(fileName, lines);
            Console.WriteLine($"Journal successfully saved to {fileName}!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the journal: {ex.Message}");
        }
    }

    public void LoadFromFile(string fileName)
    {
        try
        {
            if (File.Exists(fileName))
            {
                entries.Clear();
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    entries.Add(Entry.FromFileFormat(line));
                }
                Console.WriteLine($"Journal successfully loaded from {fileName}!");
            }
            else
            {
                Console.WriteLine($"File {fileName} does not exist. Please try again.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the journal: {ex.Message}");
        }
    }
}