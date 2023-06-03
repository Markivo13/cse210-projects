using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    // Listing activity
    public class ListingActivity : Activity
    {
        private List<string> _prompts;

        public ListingActivity()
        {
            _prompts = new List<string>
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

            string prompt = _prompts[random.Next(_prompts.Count)];
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
}
