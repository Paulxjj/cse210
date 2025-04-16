public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine($"You lost {Points} points for this negative action.");
        return -Points;
    }

    public override bool IsComplete()
    {
        return false; // Negative goals are never "complete"
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal|{Name}|{Description}|{Points}";
    }

    public override string GetDetailsString()
    {
        return $"[ ] {Name} - {Description} (Penalty: {Points} points)";
    }
}