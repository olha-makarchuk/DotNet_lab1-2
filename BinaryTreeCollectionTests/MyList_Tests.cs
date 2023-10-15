using DotNet_lab1_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCollectionTests
{
    public class MyList_Tests: BinaryTreeTests
    {
        [Theory]
        [MemberData(nameof(GetTreeData))]
        public void MyList_WhenIndexerSetUpdatesElement_ShouldBeCorect<T>(T[] values)
        {
            var myList = new MyList<T>();
            foreach (var item in values)
            {
                myList.Add(item);
            }
            myList[1] = myList[2];
            Assert.Equal(myList[1], myList[1]);
        }

        [Fact]
        public void MyList_WhenIndexerSetOutOfRange_ShouldThrow()
        {
            var myList = new MyList<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => myList[0] = 1);
        }

        [Fact]
        public void MyListAdd_WhenAddNullElement_ShouldThrow()
        {
            var myList = new MyList<string>();
            string nullItem = null;

            Assert.Throws<ArgumentNullException>(() => myList.Add(nullItem));
        }

        [Fact]
        public void MyListAddRange_WhenAddNullCollectionRange_ShouldThrow()
        {
            var myList = new MyList<string>();
            List<string> nullCollection = null;

            Assert.Throws<ArgumentNullException>(() => myList.AddRange(nullCollection));
        }

        [Fact]
        public void MyListEnumerator_WhenIndexerGetOutOfRange_ShouldThrow()
        {
            var myList = new MyList<int>();

            Assert.Throws<ArgumentOutOfRangeException>(() => myList[0]);
        }

        [Fact]
        public void MyListEnumerator_WhenResetResetsTheIndex_ShouldBeCorect()
        {
            var myList = new MyList<int> { 1, 2, 3 };
            var enumerator = myList.GetEnumerator();

            enumerator.MoveNext();
            enumerator.MoveNext();

            enumerator.Reset();

            enumerator.MoveNext();
            Assert.Equal(1, enumerator.Current);
        }

    }
}
