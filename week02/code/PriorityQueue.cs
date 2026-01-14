using System;
using System.Collections.Generic;

namespace UniqueNsikakQueues
{
    // Generic priority queue item
    public class PriorityQueueItem<T>
    {
        public T Value { get; set; }
        public int Priority { get; set; }
    }

    // Priority queue with FIFO behavior for same-priority items
    public class PriorityQueue<T>
    {
        private List<PriorityQueueItem<T>> queue = new List<PriorityQueueItem<T>>();

        public void Enqueue(T value, int priority)
        {
            queue.Add(new PriorityQueueItem<T> { Value = value, Priority = priority });
        }

        public T Dequeue()
        {
            if (queue.Count == 0)
                throw new InvalidOperationException("The queue is empty.");

            int highest = int.MinValue;
            int index = -1;

            // Find highest priority
            for (int i = 0; i < queue.Count; i++)
            {
                if (queue[i].Priority > highest)
                {
                    highest = queue[i].Priority;
                    index = i;
                }
            }

            var item = queue[index];
            queue.RemoveAt(index);
            return item.Value;
        }

        public int Count => queue.Count;
    }
}
