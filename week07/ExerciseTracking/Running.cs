using System;

namespace ExerciseTracking.Models
{
    public class Running : Activity
    {
        private double _distance; // in miles

        public Running(DateTime date, int minutes, double distance) : base(date, minutes)
        {
            _distance = distance;
        }

        public override double GetDistance()
        {
            return _distance;
        }

        public override double GetSpeed()
        {
            return (_distance / Minutes) * 60;
        }

        public override double GetPace()
        {
            return Minutes / _distance;
        }

        public override string GetSummary()
        {
            return $"{base.GetSummary()} Running - Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
        }
    }
}