using System;

namespace MindfulnessApp
{
    // Main program
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Mindfulness App!");

            while (true)
            {
                Console.WriteLine("\nPlease choose an activity:");
                Console.WriteLine("1. Breathing");
                Console.WriteLine("2. Reflection");
                Console.WriteLine("3. Listing");
                Console.WriteLine("4. Exit");

                Console.Write("Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        BreathingActivity breathingActivity = new BreathingActivity();
                        breathingActivity.Start();
                        breathingActivity.PerformBreathing();
                        breathingActivity.End();
                        break;
                    case 2:
                        ReflectionActivity reflectionActivity = new ReflectionActivity();
                        reflectionActivity.Start();
                        reflectionActivity.PerformReflection();
                        reflectionActivity.End();
                        break;
                    case 3:
                        ListingActivity listingActivity = new ListingActivity();
                        listingActivity.Start();
                        listingActivity.PerformListing();
                        listingActivity.End();
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using the Mindfulness App. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
