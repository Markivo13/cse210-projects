using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    // Reflection activity
    public class ReflectionActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _questions;

        public ReflectionActivity()
        {
            _prompts = new List<string>
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            _questions = new List<string>
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
                string prompt = _prompts[random.Next(_prompts.Count)];
                Console.WriteLine(prompt);
                Thread.Sleep(1000);

                foreach (string question in _questions)
                {
                    Console.WriteLine(question);
                    Thread.Sleep(3000);
                }

                countdown -= _questions.Count + 1;
            }
        }
    }
}
