using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsWithDuplicates
{
    class Startup
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] numbers = new int[k];

            Combinations(numbers, 0, n, 1);
        }

        private static void Combinations(int[] numbers, int currentIndex, int n, int value)
        {
            if (currentIndex == numbers.Length)
            {
                Console.WriteLine(string.Join(", ", numbers));
                return;
            }

            for (int i = value; i <= n; i++)
            {
                numbers[currentIndex] = i;
                Combinations(numbers, currentIndex + 1, n, i);
            }
        }
    }
}
