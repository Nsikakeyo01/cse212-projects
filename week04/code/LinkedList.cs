using System.Collections;

/// <summary>
/// A doubly linked list of integers with standard operations.
/// </summary>
public class LinkedList : IEnumerable<int>
{
    private Node? firstNode;
    private Node? lastNode;

    /// <summary>
    /// Insert a new value at the front of the list.
    /// </summary>
    public void InsertHead(int value)
    {
        Node newNode = new(value);

        if (firstNode is null)
        {
            firstNode = newNode;
            lastNode = newNode;
        }
        else
        {
            newNode.Next = firstNode;
            firstNode.Prev = newNode;
            firstNode = newNode;
        }
    }

    /// <summary>
    /// Insert a new value at the end of the list.
    /// </summary>
    public void InsertTail(int value)
    {
        Node newNode = new(value);

        if (lastNode is null)
        {
            firstNode = newNode;
            lastNode = newNode;
        }
        else
        {
            lastNode.Next = newNode;
            newNode.Prev = lastNode;
            lastNode = newNode;
        }
    }

    /// <summary>
    /// Remove the first node of the list.
    /// </summary>
    public void RemoveHead()
    {
        if (firstNode == lastNode)
        {
            firstNode = null;
            lastNode = null;
        }
        else if (firstNode is not null)
        {
            firstNode.Next!.Prev = null;
            firstNode = firstNode.Next;
        }
    }

    /// <summary>
    /// Remove the last node of the list.
    /// </summary>
    public void RemoveTail()
    {
        if (firstNode == lastNode)
        {
            firstNode = null;
            lastNode = null;
        }
        else if (lastNode is not null)
        {
            lastNode.Prev!.Next = null;
            lastNode = lastNode.Prev;
        }
    }

    /// <summary>
    /// Insert a new value immediately after the first occurrence of a target value.
    /// </summary>
    public void InsertAfter(int targetValue, int newValue)
    {
        Node? current = firstNode;
        while (current is not null)
        {
            if (current.Data == targetValue)
            {
                if (current == lastNode)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = current;
                    newNode.Next = current.Next;
                    current.Next!.Prev = newNode;
                    current.Next = newNode;
                }
                return;
            }
            current = current.Next;
        }
    }

    /// <summary>
    /// Remove the first node that contains the specified value.
    /// </summary>
    public void Remove(int value)
    {
        Node? current = firstNode;

        while (current is not null)
        {
            if (current.Data == value)
            {
                if (current == firstNode)
                {
                    RemoveHead();
                }
                else if (current == lastNode)
                {
                    RemoveTail();
                }
                else
                {
                    current.Prev!.Next = current.Next;
                    current.Next!.Prev = current.Prev;
                }
                return;
            }
            current = current.Next;
        }
    }

    /// <summary>
    /// Replace all occurrences of oldValue with newValue.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? current = firstNode;

        while (current is not null)
        {
            if (current.Data == oldValue)
            {
                current.Data = newValue;
            }
            current = current.Next;
        }
    }

    /// <summary>
    /// Forward iteration for foreach loops.
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary>
    /// Forward iteration using IEnumerator<int>.
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        Node? current = firstNode;

        while (current is not null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    /// <summary>
    /// Reverse iteration using IEnumerable.
    /// </summary>
    public IEnumerable Reverse()
    {
        Node? current = lastNode;

        while (current is not null)
        {
            yield return current.Data;
            current = current.Prev;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Helper for testing if list is empty.
    public bool HeadAndTailAreNull()
    {
        return firstNode is null && lastNode is null;
    }

    // Helper for testing if list has elements.
    public bool HeadAndTailAreNotNull()
    {
        return firstNode is not null && lastNode is not null;
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}