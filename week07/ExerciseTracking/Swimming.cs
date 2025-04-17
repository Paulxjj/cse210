using System;

namespace ExerciseTracking.Models
{
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            return (_laps * 50) / 1000.0 * 0.62; // Convert meters to miles
        }

        public override double GetSpeed()
        {
            return (GetDistance() / Minutes) * 60;
        }

        public override double GetPace()
        {
            return Minutes / GetDistance();
        }

        public override string GetSummary()
        {
            return $"{base.GetSummary()} Swimming - Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
        }
    }
}