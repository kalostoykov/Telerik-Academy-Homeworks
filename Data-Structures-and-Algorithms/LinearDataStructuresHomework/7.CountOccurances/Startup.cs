using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.CountOccurances
{
    class Startup
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> occuranceStorage = new Dictionary<int, int>();

            int[] sequence = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            foreach (int number in sequence)
            {
                if (occuranceStorage.ContainsKey(number))
                {
                    occuranceStorage[number]++;
                }
                else
                {
                    occuranceStorage[number] = 1;
                }
            }
            
            foreach (int key in occuranceStorage.Keys)
            {
                Console.WriteLine($"Number: {key} -> {occuranceStorage[key]} times");
            }

        }
    }
}
