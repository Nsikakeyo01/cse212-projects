using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityQueueItem> queue = new List<PriorityQueueItem>();

    // REQUIRED by template/tests
    public void AddPerson(string name, int priority)
    {
        queue.Add(new PriorityQueueItem(name, priority));
    }

    // REQUIRED by instructor tests (this was missing)
    public void Enqueue(string name, int priority)
    {
        AddPerson(name, priority);
    }

    // REQUIRED by template/tests
    public string Dequeue()
    {
        if (queue.Count == 0)
            throw new InvalidOperationException("No one in the queue.");

        int highestPriority = int.MinValue;
        int index = 0;

        for (int i = 0; i < queue.Count; i++)
        {
            if (queue[i].Priority > highestPriority)
            {
                highestPriority = queue[i].Priority;
                index = i;
            }
        }

        string name = queue[index].Name;
        queue.RemoveAt(index);
        return name;
    }

    // REQUIRED property
    public int Length => queue.Count;
}

public class PriorityQueueItem
{
    public string Name { get; set; }
    public int Priority { get; set; }

    public PriorityQueueItem(string name, int priority)
    {
        Name = name;
        Priority = priority;
    }
}
