using DotNet_lab1_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCollectionTests
{
    public class Remove_Tests: BinaryTreeTests
    {
        [Theory]
        [MemberData(nameof(GetTreeData))]
        public void Remove_WhenRemovedElementsAreNotContained_ShouldBeFalse<T>(T[] values)
        {
            var tree = new BinaryTree<T>();

            foreach (var value in values)
            {
                tree.Add(value);
            }

            foreach (var value in values)
            {
                tree.Remove(value);
                Assert.False(tree.Contains(value));
            }
        }

        [Fact]
        public void Remove_WhenRemovedElementsFromEmptyTree_ShouldThrow()
        {
            var tree = new BinaryTree<int>();

            Assert.Throws<InvalidOperationException>(() => tree.Remove(5));
        }

        [Fact]
        public void Remove_WhenRemovedElementThatNotContainedInTree_ShouldThrow()
        {
            var tree = new BinaryTree<int>();

            tree.Add(4);
            tree.Add(1);
            tree.Add(6);
            tree.Add(7);
            tree.Add(3);

            Assert.Throws<ArgumentException>(() => tree.Remove(5));
        }

        [Fact]
        public void Remove_WhenRemoveElementAndElementReplaceWithMinValue_ShouldBeCorect()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();

            binaryTree.Add(4);
            binaryTree.Add(2);
            binaryTree.Add(6);
            binaryTree.Add(1);
            binaryTree.Add(3);
            binaryTree.Add(5);

            int elementToRemove = 4;
            binaryTree.Remove(elementToRemove);

            var expectedValues = new List<int> { 1, 2, 3, 5, 6};
            var actualValues = binaryTree.Inorder().ToList();

            Assert.Equal(expectedValues, actualValues);
        }

        [Fact]
        public void Remove_WhenRemovesValue_ShouldBeFalse()
        {
            var node = new Node<int>(10);
            node.Add(5);
            node.Add(15);

            node.Remove(node, 15);

            bool containsRemovedValue = node.Contains(15);

            Assert.False(containsRemovedValue);
        }
    }
}
