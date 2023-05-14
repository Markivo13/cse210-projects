class random_question

{
    string [] questions = {
    "Who was the most interesting person I interacted with today?",
    "What was the best part of my day?",
    "How did I see the hand of the Lord in my life today?",
    "What was the strongest emotion I felt today?",
    "If I had one thing I could do over today, what would it be?",
    "What am I proud of?",
    "When was the last time I was moved to tears in joyous laughter?",
    "What brighs you joy?",
    "Describe a place where you felt happiest.",
    "What was you greatest fear, and how did you conquer it?",
    "Write a letter to someone that you always want to thank but have never had the chance to do so.",
    "What is something that you would like to change about yourself? How can you change it?",
    "Describe your dream job/partner/house.",
    "If you are granted a wish, what would you wish for and why?",
    "If you are a superhero, what superpower would you like to have and how would you use it?",
    "Write a letter to someone that you care about to tell them how you feel.",
    "Reflect and write letters to yourself with constructive feedback to improve yourself.",
    "Write about the people around you to describe what they are like, and what are your views about their actions etc.",
    "You can also record voice memos if you feel more comfortable to say those feelings out before writing them down!",
    "List down a bucket list with the things that you have always wanted to do.",
    "Where do you see yourself in the next 1, 3, 5, 10 years from now?",
    "What is something that you would like to achieve? How do you plan on reaching your goal(s)?",
    "How could you make someone you care about feel better if he/she just lost something important to them?"

    };
    public string random_Question()
    {
        Random random = new Random();
        int index = random.Next(0, questions.Length);
        return questions[index];
    }
}
