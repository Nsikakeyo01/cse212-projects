using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniqueNsikakQueues;

namespace UniqueNsikakQueues.Tests
{
    [TestClass]
    public class TakingTurnsQueue_Tests
    {
        [TestMethod]
        public void Test_Turns_Decrement()
        {
            var queue = new TakingTurnsQueue();
            var alice = new Person { Name = "Alice", Turns = 3 };
            queue.AddPerson(alice);

            var first = queue.GetNextPerson();
            Assert.AreEqual("Alice", first.Name);
            Assert.AreEqual(2, first.Turns); // Decremented correctly

            var second = queue.GetNextPerson();
            Assert.AreEqual("Alice", second.Name);
            Assert.AreEqual(1, second.Turns); // Decremented again
        }

        [TestMethod]
        public void Test_InfiniteTurnsPerson()
        {
            var queue = new TakingTurnsQueue();
            var bob = new Person { Name = "Bob", Turns = 0 }; // infinite
            queue.AddPerson(bob);

            // Dequeue multiple times, should never empty
            for (int i = 0; i < 10; i++)
            {
                var next = queue.GetNextPerson();
                Assert.AreEqual("Bob", next.Name);
                Assert.AreEqual(0, next.Turns); // Infinite stays 0
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_EmptyQueueThrows()
        {
            var queue = new TakingTurnsQueue();
            queue.GetNextPerson();
        }
    }
}
