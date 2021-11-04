/*
 * Yu Wang
 */

using System;

namespace AssignmentOne
{
    class Program
    {
        static void Main(string[] args)
        {
            UnderstandingTypes ut = new UnderstandingTypes();
            ut.PrintOne();
            ut.PrintTwo(1);
            ut.PrintTwo(5);

            ControllingFlowAndConvertingTypes cfct = new ControllingFlowAndConvertingTypes();
            cfct.FizzBuzz(100);
            cfct.LoopPrint();
            cfct.PrintPyramid(5);
            cfct.CalculateAge();
            cfct.Greetings();
            cfct.Count24();

            GuessNumber gn = new GuessNumber();
            gn.Guess();

            ArraysAndStrings aas = new ArraysAndStrings();
            aas.CopyArray();
            aas.WorkWithList();
            int startNum = 6, endNum = 30;
            int[] primes = aas.FindPrimesInRange(startNum, endNum);
            Console.WriteLine($"The primes between {startNum} and {endNum} are " + String.Join(',', primes));
            aas.RotateSum();
            aas.LongestSequenceEqualElem(new int[] { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 });
            aas.LongestSequenceEqualElem(new int[] { 1, 1, 1, 2, 3, 1, 3, 3 });
            aas.LongestSequenceEqualElem(new int[] { 4, 4, 4, 4 });
            aas.LongestSequenceEqualElem(new int[] { 0, 1, 1, 5, 2, 2, 6, 3 });
            aas.MostFrequentNum(new int[] { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 });
            aas.MostFrequentNum(new int[] { 7, 7, 7, 0, 2, 2, 2, 0, 10, 10, 10 });

            aas.ReverseString();
            aas.ReverseWords();
            aas.ExtractPalindromes("Hi,exe? ABBA! Hog fully a string: ExE. Bob");
            aas.ParseURL("https://www.apple.com/iphone");
            aas.ParseURL("ftp://www.example.com/employee");
            aas.ParseURL("https://www.google.com/");
            aas.ParseURL("www.apple.com");

        }
    }
}
