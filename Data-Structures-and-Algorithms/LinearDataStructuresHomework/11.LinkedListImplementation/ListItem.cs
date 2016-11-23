using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.LinkedListImplementation
{
    public class ListItem<T> 
    {
        T value;
        ListItem<T> next;

        public ListItem(T value)
        {
            this.Value = value;
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public ListItem<T> Next
        {
            get
            {
                return this.next;
            }

            set
            {
                this.next = value;
            }
        }
    }
}
