using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_lab1_2
{
    public class Node<T> : IComparable<T>
        where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (node.CompareTo(Data) == -1)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Add(data);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Add(data);
                }
            }
        }

        public bool Find(T data)
        {
            var node = new Node<T>(data);

            int comparisonResult = node.CompareTo(Data);

            if (comparisonResult == 0)
            {
                return true;
            }
            else if (comparisonResult < 0 && Left != null)
            {
                return Left.Find(data);
            }
            else if (comparisonResult > 0 && Right != null)
            {
                return Right.Find(data);
            }

            return false;
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }
    }
}
