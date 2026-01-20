/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them. 
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        // 1. Remove the person from the front of the line
        Person person = _people.Dequeue();

        // 2. Relay Logic
        // If Turns <= 0, it is infinite. It must always return to the queue.
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        // If Turns > 1, it still has turns left after this one.
        // We decrement it and put it back at the end of the queue.
        else if (person.Turns > 1)
        {
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        // If Turns == 1, it uses its last turn and does NOT return to the queue.
        else
        {
            person.Turns -= 1; 
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}