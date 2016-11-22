using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.ReverseIntegerNumbers
{
    class Startup
    {
        static void Main(string[] args)
        {
            Stack<int> sequence = new Stack<int>();
            int numberCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCount; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                sequence.Push(currentNumber);
            }

            sequence.Reverse();

            for (int i = 0; i < sequence.Count; i++)
            {
                Console.WriteLine(sequence.ElementAt(i));
            }
        }
    }
}
