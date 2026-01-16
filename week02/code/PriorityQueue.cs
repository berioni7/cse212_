using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var highPriorityIndex = 0;
        // index < _queue.Count to check all items
        for (int index = 1; index < _queue.Count; index++) 
        {
            // We use ‘>’ to keep the FIRST item found in case of a tie (FIFO).
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
                highPriorityIndex = index;
        }

        var value = _queue[highPriorityIndex].Value;
        
        // Now we remove the item from the list after getting the value
        _queue.RemoveAt(highPriorityIndex); 
        
        return value;
    }

    public override string ToString() => $"[{string.Join(", ", _queue)}]";
}