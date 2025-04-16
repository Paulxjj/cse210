using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"You have {_score} points\n");

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Exit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void ListGoalDetails()
    {
        Console.Clear();
        Console.WriteLine("Your Goals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    private void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Progress Goal");
        Console.WriteLine("5. Negative Goal");
        Console.Write("What type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid input. Points must be a number. Press Enter to return to the menu...");
            Console.ReadLine();
            return;
        }

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                if (!int.TryParse(Console.ReadLine(), out int targetCount))
                {
                    Console.WriteLine("Invalid input. Target count must be a number. Press Enter to return to the menu...");
                    Console.ReadLine();
                    return;
                }
                Console.Write("What is the bonus for accomplishing it that many times? ");
                if (!int.TryParse(Console.ReadLine(), out int bonusPoints))
                {
                    Console.WriteLine("Invalid input. Bonus points must be a number. Press Enter to return to the menu...");
                    Console.ReadLine();
                    return;
                }
                _goals.Add(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
                break;
            case "4":
                Console.Write("What is the target progress for this goal? ");
                if (!int.TryParse(Console.ReadLine(), out int targetProgress))
                {
                    Console.WriteLine("Invalid input. Target progress must be a number. Press Enter to return to the menu...");
                    Console.ReadLine();
                    return;
                }
                _goals.Add(new ProgressGoal(name, description, points, targetProgress));
                break;
            case "5":
                _goals.Add(new NegativeGoal(name, description, points));
                break;
            default:
                Console.WriteLine("Invalid choice. Press Enter to return to the menu...");
                Console.ReadLine();
                break;
        }
    }

    private void RecordEvent()
    {
        Console.Clear();
        Console.WriteLine("Select a goal to record:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].Name}");
        }
        Console.Write("Enter choice: ");
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid choice. Press Enter to return to the menu...");
            Console.ReadLine();
            return;
        }

        int pointsEarned = _goals[choice - 1].RecordEvent();
        _score += pointsEarned;
        Console.WriteLine($"Event recorded! You earned {pointsEarned} points. Press Enter to return to the menu...");
        Console.ReadLine();
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);
                foreach (var goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully. Press Enter to return to the menu...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}. Press Enter to return to the menu...");
        }
        Console.ReadLine();
    }

    private void LoadGoals()
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. Press Enter to return to the menu...");
            Console.ReadLine();
            return;
        }

        try
        {
            _goals.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                _score = int.Parse(reader.ReadLine());
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string type = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    switch (type)
                    {
                        case "SimpleGoal":
                            bool isComplete = bool.Parse(parts[4]);
                            var simpleGoal = new SimpleGoal(name, description, points);
                            if (isComplete) simpleGoal.RecordEvent();
                            _goals.Add(simpleGoal);
                            break;
                        case "EternalGoal":
                            _goals.Add(new EternalGoal(name, description, points));
                            break;
                        case "ChecklistGoal":
                            int timesCompleted = int.Parse(parts[4]);
                            int targetCount = int.Parse(parts[5]);
                            int bonusPoints = int.Parse(parts[6]);
                            var checklistGoal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                            for (int i = 0; i < timesCompleted; i++) checklistGoal.RecordEvent();
                            _goals.Add(checklistGoal);
                            break;
                        case "ProgressGoal":
                            int currentProgress = int.Parse(parts[4]);
                            int targetProgress = int.Parse(parts[5]);
                            var progressGoal = new ProgressGoal(name, description, points, targetProgress);
                            progressGoal.RecordEvent(); // Simulate progress
                            _goals.Add(progressGoal);
                            break;
                        case "NegativeGoal":
                            _goals.Add(new NegativeGoal(name, description, points));
                            break;
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully. Press Enter to return to the menu...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}. Press Enter to return to the menu...");
        }
        Console.ReadLine();
    }
}