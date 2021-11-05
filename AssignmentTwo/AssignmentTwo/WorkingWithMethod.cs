using System;
using System.Collections.Generic;

namespace AssignmentTwo
{
    class WorkingWithMethod
    {
        public int[] GenerateNumbers(int length = 10)
        {
            int[] arr = new int[length];
            for (int i = 0; i < length; ++i)
            {
                arr[i] = i + 1;
            }
            Console.WriteLine(string.Join(", ", arr));
            return arr;
        }

        public void Reverse(int[] arr)
        {
            Array.Reverse(arr);
        }

        public void PrintNumbers(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        private int FibonacciHelper(int pos, int[] previousRes)
        {
            if (pos == 1 || pos == 2) return 1;
            return previousRes[pos] > 0 ? previousRes[pos] 
                : FibonacciHelper(pos - 1, previousRes) + FibonacciHelper(pos - 2, previousRes);
        }

        public int Fibonacci(int pos)
        {
            return FibonacciHelper(pos, new int[pos + 1]);
        }

        public int CountWorkingDays(string startDateStr, string endDateStr)
        {
            HashSet<string> holiday = new HashSet<string>()
            {
                "01/01", "01/18", "01/20", "02/15", "05/31", "06/18", "07/05", "09/06", "10/11", "11/25", "12/24"
            };


            DateTime startDate = new DateTime(int.Parse(startDateStr.Substring(7, 4)),
                int.Parse(startDateStr.Substring(1, 2)),
                int.Parse(startDateStr.Substring(4, 2)));
            DateTime endDate = new DateTime(int.Parse(endDateStr.Substring(7, 4)),
                int.Parse(endDateStr.Substring(1, 2)),
                int.Parse(endDateStr.Substring(4, 2)));
            int count = 0;
            for (DateTime d = startDate; d <= endDate; d = d.AddDays(1))
            {
                if ((d.DayOfWeek == DayOfWeek.Saturday) || (d.DayOfWeek == DayOfWeek.Sunday)) continue;
                if (holiday.Contains(d.Month + "/" + d.Day)) continue;
                ++count;
            }
            return count;

        }
    }
}
