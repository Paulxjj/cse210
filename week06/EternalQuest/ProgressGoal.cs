public class ProgressGoal : Goal
{
    private int _currentProgress;
    private int _targetProgress;

    public ProgressGoal(string name, string description, int points, int targetProgress)
        : base(name, description, points)
    {
        _currentProgress = 0;
        _targetProgress = targetProgress;
    }

    public override int RecordEvent()
    {
        Console.Write("Enter progress made: ");
        int progress = int.Parse(Console.ReadLine());
        _currentProgress += progress;

        if (_currentProgress >= _targetProgress)
        {
            Console.WriteLine("Congratulations! You completed the goal!");
            return Points;
        }

        Console.WriteLine($"Progress updated: {_currentProgress}/{_targetProgress}");
        return 0;
    }

    public override bool IsComplete()
    {
        return _currentProgress >= _targetProgress;
    }

    public override string GetStringRepresentation()
    {
        return $"ProgressGoal|{Name}|{Description}|{Points}|{_currentProgress}|{_targetProgress}";
    }

    public override string GetDetailsString()
    {
        return $"{(IsComplete() ? "[X]" : "[ ]")} {Name} - {Description} (Progress: {_currentProgress}/{_targetProgress})";
    }
}