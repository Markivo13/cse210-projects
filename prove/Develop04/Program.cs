using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    // Base class for all activities
    public abstract class Activity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }

        public virtual void Start()
        {
            Console.WriteLine($"Starting {Name} activity...");
            Console.WriteLine(Description);
            Console.WriteLine("Please set the duration in seconds: ");
            Duration = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Prepare to begin in 3 seconds...");
            Thread.Sleep(3000);
        }

        public virtual void End()
        {
            Console.WriteLine("Great job!");
            Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
            Console.WriteLine("Pausing for 3 seconds before finishing...");
            Thread.Sleep(3000);
        }
    }

    // Breathing activity
    public class BreathingActivity : Activity
    {
        public override void Start()
        {
            Name = "Breathing";
            Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
            base.Start();
        }

        public override void End()
        {
            base.End();
        }

        public void PerformBreathing()
        {
            int countdown = Duration;

            while (countdown > 0)
            {
                Console.WriteLine("Breathe in...");
                Thread.Sleep(3000);
                Console.WriteLine("Breathe out...");
                Thread.Sleep(3000);
                countdown -= 2;
            }
        }
    }

    // Reflection activity
    public class ReflectionActivity : Activity
    {
        private List<string> prompts;
        private List<string> questions;

        public ReflectionActivity()
        {
            prompts = new List<string>
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            questions = new List<string>
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };
        }

        public override void Start()
        {
            Name = "Reflection";
            Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
            base.Start();
        }

        public override void End()
        {
            base.End();
        }

        public void PerformReflection()
        {
            Random random = new Random();
            int countdown = Duration;

            while (countdown > 0)
            {
                string prompt = prompts[random.Next(prompts.Count)];
                Console.WriteLine(prompt);
                Thread.Sleep(1000);

                foreach (string question in questions)
                {
                    Console.WriteLine(question);
                    Thread.Sleep(3000);
                }

                countdown -= questions.Count + 1;
            }
        }
    }

    // Listing activity
    public class ListingActivity : Activity
    {
        private List<string> prompts;

        public ListingActivity()
        {
            prompts = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };
        }

        public override void Start()
        {
            Name = "Listing";
            Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
            base.Start();
        }

        public override void End()
        {
            base.End();
        }

        public void PerformListing()
        {
            Random random = new Random();
            int countdown = Duration;
            int itemCount = 0;

            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine(prompt);
            Thread.Sleep(3000);

            while (countdown > 0)
            {
                Console.WriteLine("Enter an item: ");
                Console.ReadLine();
                itemCount++;
                countdown--;
            }

            Console.WriteLine($"You listed {itemCount} items.");
        }
    }

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
