﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_lab1_2
{
    public class BinaryTree<T>: ICollection<T>
    {
        public event EventHandler<BinaryTreeEventsArgs<T>> ItemAdded;
        public event EventHandler<BinaryTreeEventsArgs<T>> ItemContained;
        public event EventHandler<BinaryTreeEventsArgs<T>> ItemRemoved;
        public event EventHandler ItemCleaned;

        public Node<T> Root { get; private set; }
        public int Count { get; private set; }

        public bool IsReadOnly => false;

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
                InvokeItemAdded(data);
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
        public void Clear()
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
            bool success = Contains(data);

            if (Root == null)
            {
                throw new InvalidOperationException("Cannot remove from an empty tree.");
            }
            if (!success)
            {
                throw new ArgumentException(nameof(Root.Data), "The element is not contains in collection.");
            }
            if (success)
            {
                Root = Root.Remove(Root, data);
                Count--;
                InvokeItemRemoved(data);
            }

            return success;
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

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Array index cannot be negative.");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("The destination array does not have enough space.");
            }

            CopyTo(Root, array, ref arrayIndex);
        }

        private void CopyTo(Node<T> node, T[] array, ref int index)
        {
            if (node != null)
            {
                array[index++] = node.Data;
                CopyTo(node.Left, array, ref index);
                CopyTo(node.Right, array, ref index);
            }
        }
        
        private void InvokeItemAdded(T data) => ItemAdded?.Invoke(this, new BinaryTreeEventsArgs<T>(data));
        private void InvokeItemContained(T data) => ItemContained?.Invoke(this, new BinaryTreeEventsArgs<T>(data));
        private void InvokeItemRemoved(T data) => ItemRemoved?.Invoke(this, new BinaryTreeEventsArgs<T>(data));
        
        public IEnumerator<T> GetEnumerator()
        {
            return Preorder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
