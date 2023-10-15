using DotNet_lab1_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCollectionTests
{
    public class CopyTo_Tests : BinaryTreeTests
    {
        [Theory]
        [MemberData(nameof(GetTreeData))]
        public void CopyTo_WhenCopiedTreeToArray_ShouldContainsOfElements<T>(T[] values)
        {
            var tree = new BinaryTree<T>();

            foreach (var value in values)
            {
                tree.Add(value);
            }

            T[] array = new T[tree.Count];
            int number = 0;
            tree.CopyTo(array, number);

            Assert.Equal(values.Length, array.Length);

            for (int i = 0; i < values.Length; i++)
            {
                Assert.Contains(values[i], array);
            }
        }

        [Fact]
        public void CopyTo_WhenCopyWithNegativeIndex_ShouldThrow()
        {
            var tree = new BinaryTree<int>();
            tree.Add(1);
            tree.Add(2);

            int[] array = new int[2];

            Assert.Throws<ArgumentOutOfRangeException>(() => tree.CopyTo(array, -2));
        }

        [Fact]
        public void CopyTo_WhenCopyToArrayWhichHaveNotEnoughSpace_ShouldThrow()
        {
            var tree = new BinaryTree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);

            int[] array = new int[1];

            Assert.Throws<ArgumentException>(() => tree.CopyTo(array, 1));
        }
    }
}