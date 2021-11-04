using System;
using System.Text;

namespace AssignmentOne
{
    class ControllingFlowAndConvertingTypes
    {
        public void FizzBuzz(int n=100)
        {
            for(int i = 1; i <= n; ++i)
            {
                StringBuilder sb = new StringBuilder();
                if (i % 3 == 0)
                {
                    sb.Append("fizz");
                }
                if (i % 5 == 0)
                {
                    sb.Append("buzz");
                }
                if (sb.Length > 0)
                {
                    Console.WriteLine($"Number {i}: {sb}");
                }
            }
        }

        public void LoopPrint()
        {
            int max = 500;
            if (max > byte.MaxValue)
            {
                Console.WriteLine("Err: Will cause infinite loop.");
                return;
            }
            for (byte i = 0; i < max; i++)
            {

                Console.WriteLine(i);
            }
        }

        public void PrintPyramid(int level)
        {
            for (int i = 1; i <= level; ++i)
            {
                for (int j = 1; j <= level - i; ++j)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k < i * 2; ++k)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public void CalculateAge()
        {
            DateTime birthDate = new DateTime(2008, 4, 1, 0, 0, 0);
            DateTime now = DateTime.Now;
            int age = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;
            int days = (now.Date - birthDate.Date).Days;
            int daysToNextAnniversary = 10000 - (days % 10000);

            Console.WriteLine($"The age of a person born in April 1, 2008 is {age} years old. " 
                + $"There are {daysToNextAnniversary} days till the next 10000 day anniversary");
        }

        private string GetGreatWord()
        {
            int nowHour = DateTime.Now.Hour;
            if (nowHour < 12 && nowHour > 5)
            {
                return "morning";
            }
            if (nowHour < 18 && nowHour >= 12)
            {
                return "afternoon";
            }
            if (nowHour < 21 && nowHour >= 18)
            {
                return "evening";
            }
            if (nowHour <= 5 || nowHour >= 21)
            {
                return "night";
            }
            return "";
        }

        public void Greetings()
        {
            Console.WriteLine("Good " + GetGreatWord());
        }

        public void Count24()
        {
            for(int step = 1; step <= 4; ++step)
            {
                Console.Write(0);
                for (int i = step; i <= 24; i += step)
                {
                    Console.Write("," + i);
                }
                Console.WriteLine();
            }
        }
    }
}
