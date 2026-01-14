using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniqueNsikakQueues;

namespace UniqueNsikakQueues.Tests
{
    [TestClass]
    public class PriorityQueue_Tests
    {
        [TestMethod]
        public void Test_Dequeue_HighestPriority()
        {
            var pq = new PriorityQueue<string>();
            pq.Enqueue("Low", 1);
            pq.Enqueue("High", 5);
            pq.Enqueue("Medium", 3);

            var firstOut = pq.Dequeue();
            Assert.AreEqual("High", firstOut); // Highest priority removed first
        }

        [TestMethod]
        public void Test_SamePriority_FIFO()
        {
            var pq = new PriorityQueue<string>();
            pq.Enqueue("First", 2);
            pq.Enqueue("Second", 2);

            Assert.AreEqual("First", pq.Dequeue());  // FIFO behavior
            Assert.AreEqual("Second", pq.Dequeue());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_EmptyQueueThrows()
        {
            var pq = new PriorityQueue<string>();
            pq.Dequeue(); // Should throw
        }
    }
}
