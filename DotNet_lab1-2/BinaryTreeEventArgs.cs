using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_lab1_2
{
    public class BinaryTreeEventsArgs<T> : EventArgs
    {
        public T Value { get; }

        public BinaryTreeEventsArgs(T value)
        {
            Value = value;
        }
    }
}
