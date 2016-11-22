using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.RemoveOddAccurances
{
    class Startup
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> occuranceStorage = new Dictionary<int, int>();

            List<int> sequence = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

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
                Console.WriteLine(key + " => " + occuranceStorage[key]);

                if (occuranceStorage[key] % 2 != 0)
                {
                    sequence.RemoveAll(number => number == key);
                }
            }

            Console.WriteLine(string.Join(",", sequence));
        }
    }
}
