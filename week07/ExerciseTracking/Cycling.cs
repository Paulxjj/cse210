using System;

namespace ExerciseTracking.Models
{
    public class Cycling : Activity
    {
        private double _speed; // in mph

        public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
        {
            _speed = speed;
        }

        public override double GetDistance()
        {
            double hours = Minutes / 60.0;
            return _speed * hours;
        }

        public override double GetSpeed()
        {
            return _speed;
        }

        public override double GetPace()
        {
            return Minutes / GetDistance();
        }

        public override string GetSummary()
        {
            return $"{base.GetSummary()} Cycling - Covered {GetDistance():0.0} miles at {GetSpeed():0.0} mph, with a pace of {GetPace():0.0} min/mile.";
        }
    }
}