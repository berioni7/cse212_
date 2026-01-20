/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
{
    // Instead of Insert(0, person), we use Add to place it at the END of the list.
    _queue.Add(person); 
}

    public Person Dequeue()
{
    // Remove from the START of the list (index 0)
    var person = _queue[0];
    _queue.RemoveAt(0);
    return person;
}

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}