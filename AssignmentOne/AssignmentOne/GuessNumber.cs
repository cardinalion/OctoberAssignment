using System;

namespace AssignmentOne
{
    class GuessNumber
    {
        int correctNumber = new Random().Next(3) + 1;

        public void Guess()
        {
            Console.WriteLine("Guess my number! (Range 1 2 3)");
            while (!verify()) {};
        }

        private bool verify()
        {
            int val = int.Parse(Console.ReadLine());
            if (val == correctNumber)
            {
                Console.WriteLine("Bingo");
                return true;
            }
            if (val > correctNumber)
            {
                Console.WriteLine("Your guess is higher than the correct answer");
            }
            else
            {
                Console.WriteLine("Your guess is lower than the correct answer");
            }
            return false;
        }
    }
}
