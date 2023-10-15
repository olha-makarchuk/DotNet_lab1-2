using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_lab1_2
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] items;
        public int Count;

        public MyList()
        {
            items = new T[4];
            Count = 0;
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Element cannot be null");
            }

            if (Count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }
            items[Count] = item;
            Count++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "Collection cannot be null");
            }

            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
                }
                return items[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
                }
                items[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class MyListEnumerator : IEnumerator<T>
        {
            private readonly MyList<T> list;
            private int index;

            public MyListEnumerator(MyList<T> list)
            {
                this.list = list;
                index = -1;
            }

            public T Current => list.items[index];

            object IEnumerator.Current => Current;


            public bool MoveNext()
            {
                index++;
                return index < list.Count;
            }

            public void Reset()
            {
                index = -1;
            }

            public void Dispose()
            {
                // Немає необхідності в ресурсах для вивільнення
            }
        }
    }
}