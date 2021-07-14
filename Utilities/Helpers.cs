using System;
using System.Linq;
using System.Collections.Generic;

namespace Utilities
{
    public static class Helpers
    {

        public static void Swap(this int[] input, int position1, int position2)
        {
            if (position1 == position2) return;

            int temp = input[position1];
            input[position1] = input[position2];
            input[position2] = temp;
        }

        public static int GetRandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        public static int[] GetArrayOfNumbersFromFile(string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            List<int> input = new List<int>();

            foreach (string line in lines)
            {
                input.Add(Convert.ToInt32(line));
            }

            return input.ToArray();

        }

        public static int[] GetArrayOfOrderedNumbers(int count, int startWith = 0)
        {
            return Enumerable.Range(startWith, count).ToArray();
        }

        public static int[] GetArrayOfShuffledNumbersWithinRange(int min, int max)
        {
            var random = new Random();
            return Enumerable.Range(min, max - min + 1).OrderBy(x => random.Next()).ToArray(); 
        }

        public static int[] GetArrayOfRandomNumbers(int min, int max, int count = 20)
        {
            int Min = min;
            int Max = max;
            Random randNum = new Random();
            return Enumerable
                .Repeat(0, count)
                .Select(i => randNum.Next(Min, Max))
                .ToArray();
        }
    }
}
