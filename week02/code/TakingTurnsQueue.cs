using System;
using System.Collections.Generic;

namespace UniqueNsikakQueues
{
    // Represents a person in the taking turns queue
    public class Person
    {
        public string Name { get; set; }
        public int Turns { get; set; } // 0 or less = infinite turns
    }

    // Circular queue that manages people taking turns
    public class TakingTurnsQueue
    {
        private Queue<Person> queue = new Queue<Person>();

        // Add a person to the queue
        public void AddPerson(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            queue.Enqueue(person);
        }

        // Get the next person in line
        public Person GetNextPerson()
        {
            if (queue.Count == 0)
                throw new InvalidOperationException("The queue is empty.");

            Person next = queue.Dequeue();

            if (next.Turns > 0)
            {
                next.Turns--; // Decrement turns
                if (next.Turns > 0) // Still has turns remaining, re-enqueue
                    queue.Enqueue(next);
            }
            else
            {
                // Infinite turns (0 or negative) → always re-enqueue
                queue.Enqueue(next);
            }

            return next;
        }

        public int Count => queue.Count;
    }
}
