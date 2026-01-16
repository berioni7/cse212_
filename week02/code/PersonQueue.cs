using System.Collections.Generic;

public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    public void Enqueue(Person person)
    {
        // Adds to the end of the list to maintain FIFO order
        _queue.Add(person); 
    }

    public Person Dequeue()
    {
        if (IsEmpty()) throw new InvalidOperationException("The queue is empty.");
        
        var person = _queue[0];
        _queue.RemoveAt(0); 
        return person;
    }

    public bool IsEmpty() => Length == 0;

    public override string ToString() => $"[{string.Join(", ", _queue)}]";
}