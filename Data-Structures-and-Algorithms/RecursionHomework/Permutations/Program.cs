using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Permutations(n, new List<int>());
        }

        static void Permutations(int n, List<int> permutation)
        {
            if (permutation.Count == n)
            {
                Console.WriteLine(string.Join(", ", permutation));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (permutation.Contains(i))
                {
                    continue;
                }

                permutation.Add(i);
                Permutations(n, permutation);
                permutation.RemoveAt(permutation.Count - 1);
            }
        }
    }
}
