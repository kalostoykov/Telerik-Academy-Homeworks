using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.RemoveNegativeNumbers
{
    class Startup
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>() { 1, 2, 3, 4, 5, -1, -10, -70 };

            sequence.RemoveAll(number => number < 0);

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
