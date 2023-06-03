using System;
using System.Threading;

namespace MindfulnessApp
{
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
}
