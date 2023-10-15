using DotNet_lab1_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCollectionTests
{
    public class Add_Tests: BinaryTreeTests
    {
        [Theory]
        [MemberData(nameof(GetTreeData))]
        public void Add_WhenElementsAreContained_ShouldConteined<T>(T[] values)
        {
            var tree = new BinaryTree<T>();

            foreach (var value in values)
            {   
                tree.Add(value);
            }
            foreach (var value in values)
            {
                Assert.Contains(value, tree);
            }
        }

        [Fact]
        public void Add_WhenHasNoElement_ShouldBeFalse()
        {
            var tree = new BinaryTree<int>();

            tree.Add(1);
            tree.Add(2);
            var containerResult = tree.Contains(7);
            Assert.False(containerResult);
        }

        [Fact]
        public void Add_WhenAddNullElement_ShouldThrow()
        {
            var tree = new BinaryTree<string>();
            Assert.Throws<ArgumentNullException>(() => tree.Add(null));
        }

        [Fact]
        public void Contains_WhenElementIsNull_ShouldThrow()
        {
            var tree = new BinaryTree<string>();

            Assert.Throws<ArgumentNullException>(() => tree.Contains(null));
        }

    }
}
