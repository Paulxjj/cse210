using System;

class Program
{
    static void Main(string[] args)
    {
        // This program exceeds the requirements by:
        // Adding support for additional goal types:
        //    - ProgressGoal: Allows users to track incremental progress toward a large goal.
        //    - NegativeGoal: Deducts points for undesirable actions or bad habits.

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}