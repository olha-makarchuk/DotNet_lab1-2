using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_lab1_2
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public int Compare(T x, T y)
        {
            if (x is IComparable<T> comparable)
            {
                return comparable.CompareTo(y);
            }
            throw new ArgumentException("Type T must implement IComparable<T>");
        }

        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (Compare(data, Data) < 0)
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

        public bool Contains(T data)
        {
            int comparisonResult = Compare(data, Data);

            if (comparisonResult == 0)
            {
                return true;
            }
            else if (comparisonResult < 0 && Left != null)
            {
                return Left.Contains(data);
            }
            else if (comparisonResult > 0 && Right != null)
            {
                return Right.Contains(data);
            }

            return false;
        }

        public Node<T> Remove(Node<T> node, T data)
        {
            int comparisonResult = Compare(data, node.Data);

            if (comparisonResult < 0)
            {
                node.Left = Remove(node.Left, data);
            }
            else if (comparisonResult > 0)
            {
                node.Right = Remove(node.Right, data);
            }
            else
            {
                if (node.Left == null && node.Right == null)
                {
                    return null;
                }
                else if (node.Left == null)
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }

                T minValue = FindMinValue(node.Right);
                node.Data = minValue;
                node.Right = Remove(node.Right, minValue);
            }

            return node;
        }

        private T FindMinValue(Node<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node.Data;
        }
    }
}
