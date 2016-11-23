namespace _12.AdtStackImplementation
{
    class CustomStack<T>
    {
		private T[] data;
		//next time don't forget to set capacity to something != 0 :D
		private int capacity = 8;
		private int index = 0;
		
		private int Count { get; set; }

		public CustomStack()
		{
			this.data = new T[8];
		}

		public void Push(T item)
		{
			if (this.Count >= this.index) 
			{
				this.IncreaseCapacity();
			}

			this.data[index] = item;
			this.index++;
			this.Count++;
		}

		private void IncreaseCapacity()
		{
			this.capacity *= 2;
			T[] newData = new T[this.capacity];

			for (int i = 0; i < this.Count; i++) 
			{
				newData[i] = this.data[i];
			}

			this.data = newData;
		}

		public T Pop()
		{
			var item = this.Peek();
			this.index--;
			this.Count--;

			return item;
		}

		public T Peek()
		{
			return this.data[index - 1];
		}
    }
}
