using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Show activity log");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                new BreathingActivity().Run();
                Console.WriteLine($"Well done!!");
            }
            else if (choice == "2")
            {
                new ReflectingActivity().Run();
            }
            else if (choice == "3")
            {
                new ListingActivity().Run();
            }
            else if (choice == "4")
            {
                Console.WriteLine($"Breathing Activity performed: {BreathingActivity.GetCount()} times");
                Console.WriteLine($"Reflection Activity performed: {ReflectingActivity.GetCount()} times");
                Console.WriteLine($"Listing Activity performed: {ListingActivity.GetCount()} times");
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Console.ReadKey();
            }
        }
    }
}