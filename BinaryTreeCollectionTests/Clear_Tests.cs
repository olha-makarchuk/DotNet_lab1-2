using DotNet_lab1_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCollectionTests
{
    public class Clear_Tests: BinaryTreeTests
    {
        [Theory]
        [MemberData(nameof(GetTreeData))]
        public void Clear_WhenClearedTree_ShouldMakeTreeEmpty<T>(T[] values)
        {
            var tree = new BinaryTree<T>();
            foreach (var value in values)
            {
                tree.Add(value);
            }
            tree.Clear();

            Assert.Empty(tree);
        }
    }
}
