﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.LongestSubsequence
{
    class Startup
    {
        static List<int> FindSubsequence(List<int> sequence)
        {
            int currentCount = 1;
            int maxCount = 1;
            int maxSequenceNumber = sequence[0];

            for (int i = 0; i < sequence.Count - 1; i++)
            {
                if (sequence[i] == sequence[i + 1])
                {
                    currentCount++;
                }
                else
                {
                    currentCount = 1;
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    maxSequenceNumber = sequence[i];
                }
            }

            return Enumerable.Repeat(maxSequenceNumber, maxCount).ToList();
        }

        static void Main(string[] args)
        {
            List<int> sequence = new List<int>() { 1, 1, 2, 2, 2, 3, 4, 5, 5, 5, 5 };

            List<int> longestSubsequnce = FindSubsequence(sequence);

            Console.WriteLine(string.Join(", ", longestSubsequnce));
        }
    }
}
