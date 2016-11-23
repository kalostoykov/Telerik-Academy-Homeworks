using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.AdtQueueImplementation
{
    class Statup
    {
        static void Main(string[] args)
        {
            var queue = new CustomQueue<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enque(i);
            }

            while (queue.Count != 0)
            {
                Console.WriteLine(queue.Dequeu());
            }
        }
    }
}
