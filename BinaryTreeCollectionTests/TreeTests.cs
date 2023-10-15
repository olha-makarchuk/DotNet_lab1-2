using DotNet_lab1_2;
using System;
using System.Xml.Linq;

namespace BinaryTreeCollectionTests
{
    public class TreeTests : BinaryTreeTests
    {
        [Theory]
        [MemberData(nameof(GetEmptyTreeTestData))]
        public void GetEnumerator_WhenEmptyTree_ShouldFalse<T>(BinaryTree<T> tree)
        {
            var enumerator = tree.GetEnumerator();

            var moveNextResult = enumerator.MoveNext();
            var current = enumerator.Current;

            Assert.False(moveNextResult);
            Assert.Equal(default, current);
        }


        [Fact]
        public void Balance_WhenTreeIsBalanced_ShouldBeTrue()
        {
            var tree = new BinaryTree<int>();

            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);
            tree.Add(6);

            tree.Balance();

            int[] action = new int [tree.Count()];
            tree.CopyTo(action, 0);

            int[] expected = { 3, 1, 2, 5, 4, 6};
            var a = action.Equals(action);
            Assert.True(action.Equals(action));
        }

        [Fact]
        public void IsReadOnly_WhenReturnsReadOnly_ShouldBeFalse()
        {
            var binaryTree = new BinaryTree<int>();

            bool isReadOnly = binaryTree.IsReadOnly;

            Assert.False(isReadOnly);
        }
    }
}
