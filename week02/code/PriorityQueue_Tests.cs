using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueue_Tests
{
    [TestMethod]
    public void Test_Highest_Priority_Removed_First()
    {
        var queue = new PriorityQueue();
        queue.AddPerson("Low", 1);
        queue.AddPerson("High", 5);
        queue.AddPerson("Medium", 3);

        string first = queue.Dequeue();
        Assert.AreEqual("High", first);
    }

    [TestMethod]
    public void Test_Same_Priority_FIFO()
    {
        var queue = new PriorityQueue();
        queue.AddPerson("First", 2);
        queue.AddPerson("Second", 2);

        string first = queue.Dequeue();
        string second = queue.Dequeue();

        Assert.AreEqual("First", first);
        Assert.AreEqual("Second", second);
    }

    [TestMethod]
    public void Test_Empty_Queue_Exception()
    {
        var queue = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(
            () => queue.Dequeue()
        );

        Assert.AreEqual("No one in the queue.", ex.Message);
    }
}
