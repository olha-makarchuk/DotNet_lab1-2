using DotNet_lab1_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCollectionTests
{
    public class Compare_Tests
    {
        [Fact]
        public void Compare_ThrowsArgumentException_WhenTDoesNotImplementIComparable()
        {
            var node = new Node<MyComparableClass>(new MyComparableClass(1));

            var exception = Assert.Throws<ArgumentException>(() => node.Compare(new MyComparableClass(1), new MyComparableClass(2)));
        }


        public class MyComparableClass
        {
            public int Value { get; set; }

            public MyComparableClass(int value)
            {
                Value = value;
            }
        }
    }
}
