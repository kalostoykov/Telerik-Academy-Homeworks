using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.LinkedListImplementation
{
    public class AdtLinkedList<T> : IEnumerable<T>
    {
        public ListItem<T> First { get; private set; }

        public ListItem<T> Last { get; private set; }

        public int Count { get; private set; }

        public void Add(T item)
        {
            var newItem = new ListItem<T>(item);

            if (this.First == null)
            {
                this.First = newItem;
                this.Last = newItem;
                this.Count = 1;

                return;
            }

            this.Last.Next = newItem;
            this.Last = this.Last.Next;
            this.Count++;
        }
		
        public bool Remove(T item)
        {
            var current = this.First;

            if (current.Value.Equals(item))
            {
                this.First = this.First.Next;
                this.Count--;

                return true;
            }

            while (current.Next != null)
            {
                if (current.Next.Value.Equals(item))
                {
                    var next = current.Next;
                    current.Next = next.Next;
                    this.Count--;

                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            this.First = this.Last = null;
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            foreach (var element in this)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.First;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
