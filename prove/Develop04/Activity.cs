using System;
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
}
