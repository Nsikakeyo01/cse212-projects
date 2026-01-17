using System;
using System.Collections.Generic;

public class PriorityQueueItem
{
    public string Name { get; set; }
    public int Priority { get; set; }
}

public class PriorityQueue
{
    private List<PriorityQueueItem> queue = new List<PriorityQueueItem>();

    // Add a person with a priority
    public void AddPerson(string name, int priority)
    {
        queue.Add(new PriorityQueueItem
        {
            Name = name,
            Priority = priority
        });
    }

    // Remove the next person with the highest priority (FIFO for same priority)
    public string RemoveNext()
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

    // Property to get current queue length
    public int Length => queue.Count;
}
