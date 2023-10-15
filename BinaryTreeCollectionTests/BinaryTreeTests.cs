using DotNet_lab1_2;

namespace BinaryTreeCollectionTests
{
    public abstract class BinaryTreeTests
    {
        private static readonly int[] Numbers = { 4, 5, 1, 3, 2 };
        private static readonly string[] Letters = { "s", "ac", "ab", "p" };
        private static readonly TestObject<int>[] Objects = { new(4), new(6), new(1), new(3), new(0) };


        public static IEnumerable<object[]> GetEmptyTreeTestData()
        {
            yield return new object[] { new BinaryTree<int>() };
            yield return new object[] { new BinaryTree<string>() };
            yield return new object[] { new BinaryTree<TestObject<int>>() };
        }

        public static IEnumerable<object[]> GetTreeData()
        {
            yield return new object[] { Numbers };
            yield return new object[] { Letters };
            yield return new object[] { Objects };
        }

        protected class TestObject<T> : IComparable<TestObject<T>>
        {
            public int Value { get; set; }

            public TestObject(int value)
            {
                Value = value;
            }

            public int CompareTo(TestObject<T> other)
            {
                return Value.CompareTo(other.Value);
            }
        }
    }
}

