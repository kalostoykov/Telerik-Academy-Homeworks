using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.SortSequenceOfNumbers
{
    class Startup
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> sequence = input.Trim()
                                .Split(new char[] { ' ' })
                                .Select(int.Parse)
                                .ToList();

            sequence.Sort((a, b) => a.CompareTo(b));

            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
