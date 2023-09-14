using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_lab1_2
{
    public class BinaryTree<T>
        where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }
        public int Count { get; private set; }
    }
}
