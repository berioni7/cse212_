using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        Node newNode = new(value);
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    /// <summary>
    /// Problem 1: Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // Create the new node
        Node newNode = new(value);

        // If the list is empty, both head and tail point to the new node
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            // Connect the current tail to the new node
            newNode.Prev = _tail;
            _tail.Next = newNode;
            // Update the tail pointer to the new node
            _tail = newNode;
        }
    }

    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_head is not null)
        {
            _head.Next!.Prev = null;
            _head = _head.Next;
        }
    }

    /// <summary>
    /// Problem 2: Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // If the list is empty, there is nothing to remove
        if (_tail is null)
        {
            return;
        }

        // If there is only one node, set both head and tail to null
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            // Disconnect the last node by updating the second-to-last node's Next pointer
            _tail.Prev!.Next = null;
            // Update the tail pointer to the previous node
            _tail = _tail.Prev;
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr;
                    newNode.Next = curr.Next;
                    curr.Next!.Prev = newNode;
                    curr.Next = newNode;
                }
                return;
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Problem 3: Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If it's the head, reuse RemoveHead
                if (curr == _head)
                {
                    RemoveHead();
                }
                // If it's the tail, reuse RemoveTail
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                // If it's in the middle, bypass the current node
                else
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }
                return; // Exit after the first match is found and removed
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Problem 4: Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;
        // Iterate through the entire list
        while (curr is not null)
        {
            // If the value matches, update the data
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }
            // Move to the next node even if a replacement was made
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head;
        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Problem 5: Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // Start at the end of the list
        // Start at the tail
        Node? curr = _tail;

        // Iterate backwards using the 'Prev' pointers
        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Prev;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    public Boolean HeadAndTailAreNull() => _head is null && _tail is null;
    public Boolean HeadAndTailAreNotNull() => _head is not null && _tail is not null;
}