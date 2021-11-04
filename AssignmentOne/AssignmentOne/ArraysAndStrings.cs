using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentOne
{
    class ArraysAndStrings
    {
        public void CopyArray()
        {
            int[] firstArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] secondArr = new int[10];
            for (int i = 0; i < firstArr.Length; ++i)
            {
                secondArr[i] = firstArr[i];
            }
            Console.WriteLine($"First Array is {string.Join(",", firstArr)}, second array is {string.Join(",", secondArr)}");
        }

        public void WorkWithList()
        {
            List<string> list = new List<string>();
            while (true)
            {
                Console.WriteLine("Enter command (+ item, - item, or -- to clear # to exit)");
                string input = Console.ReadLine();
                if (input.Equals("#")) break;
                if (input.Equals("--")) list.Clear();
                else if (input.StartsWith('+')) list.Add(input.Substring(2));
                else list.Remove(input.Substring(2));
                // print items in the list
                if (list.Count > 0)
                {
                    Console.WriteLine("Current items in the list: ");
                    Console.Write(list[0]);
                    for (int i = 1; i < list.Count; ++i) Console.Write(", " + list[i]);
                    Console.WriteLine();

                } else Console.WriteLine("Your list is empty.");
                
            }
            Console.WriteLine("Thanks for using WorkWithList. Successfully exited");
        }

        public int[] FindPrimesInRange(int startNum, int endNum)
        {
            List<int> primeList = new List<int>();
            List<int> res = new List<int>();
            primeList.Add(2);
            if (startNum <= 2) res.Add(2);
            for (int i = 3; i < endNum; ++i)
            {
                bool prime = true;
                foreach (var p in primeList)
                {
                    if (i % p == 0)
                    {
                        prime = false;
                        break;
                    }
                }
                if (prime) primeList.Add(i);
                if (prime && i >= startNum) res.Add(i);
            }
            int length = res.Count;
            int[] resArr = new int[length];
            for (int i = 0; i < length; ++i)
            {
                resArr[i] = res[i];
            }
            return resArr;
        }

        public void RotateSum()
        {
            Console.WriteLine("Please input number array to rotate and sum: ");
            string[] arr = ((string)Console.ReadLine()).Split();
            int length = arr.Length;
            int[] numArray = new int[length];
            int[] resArray = new int[length];
            for (int i = 0; i < length; ++i)
            {
                numArray[i] = int.Parse(arr[i]);
            }
            Console.WriteLine("Please input rotate times: ");
            int rotate = int.Parse(Console.ReadLine());
            for (int i = 1; i <= rotate; ++i)
            {
                Console.WriteLine($"rotated{i}[] = ");
                for (int j = 0; j < length; ++j)
                {
                    int newPos = ((j - i) % length + length) % length;
                    Console.WriteLine(numArray[newPos] + " ");
                    resArray[j] += numArray[newPos];
                }
                Console.WriteLine();
            }
            Console.Write($"sum[] = {resArray[0]}");
            for (int i = 1; i < length; ++i)
            {
                Console.Write(" " + resArray[i]);
            }
            Console.WriteLine();
        }

        public void LongestSequenceEqualElem(int[] arr)
        { 
            Console.WriteLine($"Input: {string.Join(' ', arr)}");
            int startPos = 0;
            int maxLength = 1;
            int curLength = 1;
            for (int i = 1; i < arr.Length; ++i)
            {
                if (arr[i] == arr[i - 1]) ++curLength;
                if (arr[i] != arr[i - 1] || i == arr.Length - 1)
                {
                    if (curLength > maxLength)
                    {
                        maxLength = curLength;
                        startPos = i - maxLength;
                        if (i == arr.Length - 1) ++startPos;
                    }
                    curLength = 1;
                } 
            }
            Console.Write("Output:");
            for(int i = 0; i < maxLength; ++i)
            {
                Console.Write(" " + arr[startPos + i]);
            }
            Console.WriteLine();
        }

        public void MostFrequentNum(int[] arr)
        {
            Dictionary<int, int> frequency = new Dictionary<int, int>();
            List<int> maxFrequencyNum = new List<int>();
            int maxFrequency = 1;
            foreach (var i in arr){
                int value;
                if (frequency.TryGetValue(i, out value))
                {
                    frequency[i] = value + 1;
                } else
                {
                    frequency.Add(i, 1);
                }
            }
            foreach (var item in frequency)
            {
                int number = item.Key, freq = item.Value;
                if (freq > maxFrequency)
                {
                    maxFrequency = freq;
                    maxFrequencyNum.Clear();
                    maxFrequencyNum.Add(number);
                } else if (freq == maxFrequency) {
                    maxFrequencyNum.Add(number);
                }
            }
            if (maxFrequencyNum.Count == 1)
            {
                Console.WriteLine($"The number {maxFrequencyNum[0]} is the most frequent (occurs {maxFrequency} times)");
            } else
            {   // how to define leftmost? by the first occurance or the last occurance or something else?
                Console.WriteLine($"The numbers {string.Join(' ', maxFrequencyNum)} have the same maximal frequence(each occurs {maxFrequency} times)");
            }
        }

        public void ReverseString()
        {
            Console.WriteLine("Please type a string to reverse: ");
            string str = Console.ReadLine();
            char[] charArr = str.ToCharArray();
            Array.Reverse(charArr);
            Console.WriteLine("Reversing arrays using char array. Result: " + String.Join("", charArr));
            Console.Write("Reversing arrays by printing reversely. Result: ");
            for (int i = str.Length-1; i >= 0; --i)
            {
                Console.Write(str[i]);
            }
            Console.WriteLine();
        }

        public void ReverseWords()
        {
            Console.WriteLine("Please input a sentence to reverse: ");
            string sentence = Console.ReadLine();
            HashSet<char> seperators = new HashSet<char>(){'.', ',', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' '};
            List<string> words = new List<string>();
            int end = 0;
            while (end < sentence.Length)
            {
                while (end < sentence.Length && seperators.Contains(sentence[end]))
                {
                    words.Add("" + sentence[end++]);
                }
                int start = end;
                while (end < sentence.Length && !seperators.Contains(sentence[end]))
                {
                    ++end;
                }
                words.Add(sentence.Substring(start, end - start));
            }
            int left = 0, right = words.Count - 2;
            while (left < right)
            {
                while (left < right && seperators.Contains(words[left][0])) ++left;

                while (left < right && seperators.Contains(words[right][0])) --right;
                if (left >= right) break;
                string tmp = words[left];
                words[left++] = words[right];
                words[right--] = tmp;
            }
            Console.WriteLine("Reversed sentence: " + String.Join("", words));
        }

        private bool isPalindrome(string str)
        {
            int left = 0, right = str.Length - 1;
            while (left < right)
            {
                if (str[left++] != str[right--]) return false;
            }
            return true;
        }

        public void ExtractPalindromes(string str)
        {
            Console.WriteLine("Original sentence to extract palindromes: " + str);
            HashSet<string> palindromeSet = new HashSet<string>();
            int start = 0, end = 0;
            while (end < str.Length)
            {
                while (end < str.Length && !Char.IsLetter(str[end])) end++;
                start = end;
                while (end < str.Length && Char.IsLetter(str[end])) end++;
                if (isPalindrome(str.Substring(start, end - start)))
                {
                    palindromeSet.Add(str.Substring(start, end - start));
                }
            }
            foreach (var p in palindromeSet)
            {
                Console.Write(p + ", ");
            }
            Console.WriteLine();
        }

        public void ParseURL(string url)
        {
            Console.WriteLine(url);
            int serverPos = 0;
            int i = 0;
            for (; i < url.Length; ++i)
            {
                if (url[i] == ':')
                {
                    Console.WriteLine($"[protocol] = \"{url.Substring(0, i)}\"");
                    serverPos = i+3;
                    break;
                }
            }
            if (i == url.Length) Console.WriteLine($"[protocol] = \"\"");
            for (i = serverPos; i < url.Length; ++i)
            {
                if (url[i] == '/')
                {
                    
                    break;
                }
            }
            Console.WriteLine($"[server] = \"{url.Substring(serverPos, i - serverPos)}\"");
            if (i < url.Length) Console.WriteLine($"[resource] = \"{url.Substring(i+1)}\"");
            else Console.WriteLine($"[resource] = \"\"");

        }
    }
}
