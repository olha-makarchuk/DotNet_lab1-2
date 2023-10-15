using DotNet_lab1_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCollectionTests
{
    public class Events_Tests
    {
        [Fact]
        public void ItemAddedEvent_IsRaisedWhenElementIsAdded_ShouldBeTrue()
        {
            var binaryTree = new BinaryTree<int>();
            bool eventRaised = false;
            int addedValue = 42;

            binaryTree.ItemAdded += (sender, args) =>
            {
                eventRaised = true;
                Assert.Equal(addedValue, args.Value);
            };

            binaryTree.Add(addedValue);

            bool result = binaryTree.Contains(addedValue);
            
            Assert.True(eventRaised);
            Assert.True(result);
        }

        [Fact]
        public void ItemContainedEvent_IsRaisedWhenElementIsContained_ShouldBeTrue()
        {
            var binaryTree = new BinaryTree<int>();
            int containedValue = 42;
            binaryTree.Add(containedValue);
            bool eventRaised = false;

            binaryTree.ItemContained += (sender, args) =>
            {
                eventRaised = true;
                Assert.Equal(containedValue, args.Value);
            };

            bool result = binaryTree.Contains(containedValue);

            Assert.True(eventRaised);
            Assert.True(result);
        }


        [Fact]
        public void ItemRemovedEvent_IsRaisedWhenElementIsRemoved_ShouldBeTrue()
        {
            var binaryTree = new BinaryTree<int>();
            int removedValue = 42;
            binaryTree.Add(removedValue);
            bool eventRaised = false;

            binaryTree.ItemRemoved += (sender, args) =>
            {
                eventRaised = true;
                Assert.Equal(removedValue, args.Value);
            };

            bool result = binaryTree.Remove(removedValue);

            Assert.True(eventRaised);
            Assert.True(result);
        }

        [Fact]
        public void ItemCleanedEvent_IsRaisedWhenTreeIsCleared_ShouldBeTrueAndEmpty()
        {
            var binaryTree = new BinaryTree<int>();
            int addedValue = 42;
            binaryTree.Add(addedValue);
            bool eventRaised = false;

            binaryTree.ItemCleaned += (sender, args) =>
            {
                eventRaised = true;
            };

            binaryTree.Clear();

            Assert.True(eventRaised);
            Assert.Empty(binaryTree);
        }
    }
}
