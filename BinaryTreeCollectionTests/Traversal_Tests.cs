using DotNet_lab1_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCollectionTests
{
    public class Traversal_Tests: BinaryTreeTests
    {
        [Fact]
        public void Preorder_WhenThePreorderTraversalReturns_ShouldBeCorect()
        {
            var tree = new BinaryTree<int>();

            tree.Add(4);
            tree.Add(3);
            tree.Add(7);
            tree.Add(1);
            tree.Add(8);

            List<int> expected = new() { 4, 3, 1, 7, 8 };

            var actual = tree.Preorder();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Postorder_WhenThePostorderTraversalReturns_ShouldBeCorect()
        {
            var tree = new BinaryTree<int>();

            tree.Add(4);
            tree.Add(3);
            tree.Add(7);
            tree.Add(1);
            tree.Add(8);

            List<int> expected = new() { 1, 3, 8, 7, 4 };
            var actual = tree.Postorder();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetTreeData))]
        public void Inorder_WhenTheInorderTraversalReturns_ShouldBeCorect<T>(T[] values)
        {
            var tree = new BinaryTree<T>();

            foreach (var value in values)
            {
                tree.Add(value);
            }

            var expected = values.ToList();
            expected.Sort();

            var actual = tree.Inorder();

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Preorder_WhenThePreorderTraversalReturnsForEmptyTree_ShouldBeEmpty()
        {
            var tree = new BinaryTree<int>();

            var result = tree.Preorder();

            Assert.Empty(result);
        }

        [Fact]
        public void Postorder_WhenThePostorderTraversalReturnsForEmptyTree_ShouldBeEmpty()
        {
            var tree = new BinaryTree<int>();

            var result = tree.Postorder();

            Assert.Empty(result);
        }

        [Fact]
        public void Inorder_WhenTheInorderTraversalReturnsForEmptyTree_ShouldBeEmpty()
        {
            var tree = new BinaryTree<int>();

            var result = tree.Inorder();

            Assert.Empty(result);
        }
    }
}
