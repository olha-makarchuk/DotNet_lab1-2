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
        private int count;

        public MyList()
        {
            items = new T[4];
            count = 0;
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Element cannot be null");
            }

            if (count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }
            items[count] = item;
            count++;
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
                return index < list.count;
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
