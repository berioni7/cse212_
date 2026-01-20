using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities and ensure the highest is removed first.
    // Expected Result: High, Medium, Low
    // Defect(s) Found: Original code skipped the last item and didn't remove items from the list.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 5);
        pq.Enqueue("High", 10);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items with the same high priority to test FIFO.
    // Expected Result: First, Second
    // Defect(s) Found: Original code used '>=' which picked the newest item instead of the oldest.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 7);
        pq.Enqueue("Second", 7);
        pq.Enqueue("Third", 3);

        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Verify exception message when dequeuing from an empty queue.
    // Expected Result: InvalidOperationException with "The queue is empty."
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();
        var exception = Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}