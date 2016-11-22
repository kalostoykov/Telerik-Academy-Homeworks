using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.PositiveNumbersSequence
{
    public class Startup
    {
        public static void Main()
        {
            List<int> sequence = new List<int>();
            string input = String.Empty;
            int number = 0;

            while(true)
            {
                input = Console.ReadLine();
                if (input == "")
                {
                    break;
                }

                number = int.Parse(input);
                sequence.Add(number);
            }

            Console.WriteLine("Sum = " + sequence.Sum());
            Console.WriteLine("Average = " + sequence.Average());
        }
    }
}
