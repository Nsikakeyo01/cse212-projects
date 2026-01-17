using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class TakingTurnsQueue_Tests
{
    [TestMethod]
    public void Test_Turns_Decrement()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Alice", 3);

        var first = queue.GetNextPerson();
        Assert.AreEqual("Alice", first.Name);
        Assert.AreEqual(2, first.Turns); // 3 -> 2 ✅

        var second = queue.GetNextPerson();
        Assert.AreEqual("Alice", second.Name);
        Assert.AreEqual(1, second.Turns); // 2 -> 1 ✅
    }

    [TestMethod]
    public void Test_Infinite_Turns()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Bob", 0); // infinite

        for (int i = 0; i < 5; i++)
        {
            var person = queue.GetNextPerson();
            Assert.AreEqual("Bob", person.Name);
            Assert.AreEqual(0, person.Turns);
        }
    }

    [TestMethod]
    public void Test_Empty_Queue_Exception()
    {
        var queue = new TakingTurnsQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(
            () => queue.GetNextPerson()
        );

        Assert.AreEqual("No one in the queue.", ex.Message);
    }
}
