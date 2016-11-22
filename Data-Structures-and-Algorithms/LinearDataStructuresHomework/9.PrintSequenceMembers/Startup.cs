using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.PrintSequenceMembers
{
    class Startup
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            int n = int.Parse(Console.ReadLine());
            int iterations = 50;

            queue.Enqueue(n);

            for (int i = 0; i < iterations; i++)
            {
                Console.Write(queue.Peek() + ", ");

                var s = queue.Dequeue();

                queue.Enqueue(s + 1);
                queue.Enqueue((2 * n) + 1);
                queue.Enqueue(s + 2);
                
            }
        }
    }
}
