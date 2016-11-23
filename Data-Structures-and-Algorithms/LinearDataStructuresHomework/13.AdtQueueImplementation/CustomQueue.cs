using System.Collections.Generic;

namespace _13.AdtQueueImplementation
{
    class CustomQueue<T>
    {
		private LinkedList<T> queue;

        public int Count { get; private set; }

        public CustomQueue()
		{
			this.queue = new LinkedList<T>();
		}

		public void Enque(T item)
		{
            this.queue.AddLast(item);
            this.Count++;
		}

        public T Dequeu()
        {
            var item = this.Peek();
            this.queue.RemoveFirst();
            this.Count--;

            return item;
        }

        public T Peek()
        {
            return this.queue.First.Value;
        }
    }
}
