using System;

namespace _12.AdtStackImplementation
{
    class Startup
    {
        static void Main(string[] args)
        {
			CustomStack<int> stack = new CustomStack<int>();
            
			stack.Push(1);
			stack.Push(2);
			stack.Push(3);
			stack.Push(4);
			stack.Push(5);
			stack.Push(6);

            stack.Pop();

            Console.WriteLine(stack.Peek());
        }
    }
}
