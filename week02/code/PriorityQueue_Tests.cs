using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities (Low: 2, High: 10, Medium: 5).
    // Expected Result: The item with the highest priority (10) should be removed first.
    // Defect(s) Found: The original loop used "index < _queue.Count - 1", which caused it to 
    //                  skip the last item in the list. Also, the item was not being removed 
    //                  from the queue after Dequeue was called.
    public void TestPriorityQueue_HighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 2);
        pq.Enqueue("High", 10);
        pq.Enqueue("Medium", 5);

        Assert.AreEqual("High", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the SAME priority level.
    // Expected Result: The queue should follow FIFO rules, removing the first item added 
    //                  among those with the same high priority.
    // Defect(s) Found: The original code used the ">=" operator in the priority comparison. 
    //                  This caused the queue to pick the LAST item added (LIFO) instead 
    //                  of the first one (FIFO) when priorities were equal.
    public void TestPriorityQueue_FIFO_Tie()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First A", 5);
        pq.Enqueue("Second B", 5);
        pq.Enqueue("Third C", 5);

        Assert.AreEqual("First A", pq.Dequeue());
        Assert.AreEqual("Second B", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from a queue that has no items.
    // Expected Result: Should throw an InvalidOperationException with the specific 
    //                  message "The queue is empty."
    // Defect(s) Found: Needed to ensure the exception type and the error message string 
    //                  matched the requirements exactly.
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();
        try 
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e) 
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
    }
}