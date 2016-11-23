using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.LinkedListImplementation
{
    class Startup
    {
        static void Main(string[] args)
        {
            AdtLinkedList<int> list = new AdtLinkedList<int>();

            list.Add(1);
            list.Add(2);

            Console.WriteLine("-------------");
            Console.WriteLine("Count = " + list.Count);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.Remove(2);

            Console.WriteLine("-------------");
            Console.WriteLine("Count after remove = " + list.Count);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
