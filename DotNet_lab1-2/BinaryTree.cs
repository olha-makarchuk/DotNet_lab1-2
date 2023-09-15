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
        public event EventHandler<BinaryTreeEventsArgs<T>> ItemAdded;
        public event EventHandler<BinaryTreeEventsArgs<T>> ItemContained;
        public event EventHandler<BinaryTreeEventsArgs<T>> ItemRemoved;
        public event EventHandler ItemCleaned;

        public Node<T> Root { get; private set; }
        public int Count { get; private set; }

        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Data cannot be null.");
            }

            if (Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                ItemAdded?.Invoke(this, new BinaryTreeEventsArgs<T>(data));
                return;
            }

            Root.Add(data);
            Count++;
        }

        public bool Contains(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Data cannot be null.");
            }

            if (Root != null)
            {
                bool found = Root.Contains(data);

                if (found)
                {
                    InvokeItemContained(data);
                }
                return found;
            }

            return false;
        }
        public void Clean()
        {
            Root = null;
            Count = 0;
            ItemCleaned?.Invoke(this, EventArgs.Empty);

        }

        public void Balance()
        {
            var inorderList = Inorder();
            T[] sortedArray = inorderList.ToArray();
            Root = CreateBalancedBST(sortedArray, 0, sortedArray.Length - 1);
            Count = sortedArray.Length;
        }

        private Node<T> CreateBalancedBST(T[] sortedArray, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            Node<T> newNode = new Node<T>(sortedArray[mid]);

            newNode.Left = CreateBalancedBST(sortedArray, start, mid - 1);
            newNode.Right = CreateBalancedBST(sortedArray, mid + 1, end);

            return newNode;
        }

        public bool Remove(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Data cannot be null.");
            }

            bool success = Contains(data);

            if (success)
            {
                Root = Remove(Root, data);
                Count--;
                InvokeItemRemoved(data);
            }

            return success;
        }

        private Node<T> Remove(Node<T> node, T data)
        {
            if (node == null)
            {
                return null;
            }

            int comparisonResult = data.CompareTo(node.Data);

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
                if (node.Left == null)
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

        public MyList<T> Preorder()
        {
            if (Root == null)
            {
                return new MyList<T>();
            }

            return Preorder(Root);

        }

        public MyList<T> Postorder()
        {
            if (Root == null)
            {
                return new MyList<T>();
            }

            return Postorder(Root);

        }

        public MyList<T> Inorder()
        {
            if (Root == null)
            {
                return new MyList<T>();
            }

            return Inorder(Root);
        }

        private MyList<T> Preorder(Node<T> node)
        {
            var list = new MyList<T>();
            if (node != null)
            {
                list.Add(node.Data);

                if (node.Left != null)
                {
                    list.AddRange(Preorder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(Preorder(node.Right));
                }
            }
            return list;
        }

        private MyList<T> Postorder(Node<T> node)
        {
            var list = new MyList<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(Postorder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(Postorder(node.Right));
                }

                list.Add(node.Data);
            }
            return list;
        }

        private MyList<T> Inorder(Node<T> node)
        {
            var list = new MyList<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(Inorder(node.Left));
                }

                list.Add(node.Data);

                if (node.Right != null)
                {
                    list.AddRange(Inorder(node.Right));
                }
            }
            return list;
        }

        private void InvokeItemAdded(T data) => ItemAdded?.Invoke(this, new BinaryTreeEventsArgs<T>(data));
        private void InvokeItemContained(T data) => ItemContained?.Invoke(this, new BinaryTreeEventsArgs<T>(data));
        private void InvokeItemRemoved(T data) => ItemRemoved?.Invoke(this, new BinaryTreeEventsArgs<T>(data));


    }
}
