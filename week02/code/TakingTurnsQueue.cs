using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private Queue<Person> queue = new Queue<Person>();

    // Add a person to the queue
    public void AddPerson(string name, int turns)
    {
        queue.Enqueue(new Person
        {
            Name = name,
            Turns = turns
        });
    }

    // Get the next person in line
    public Person GetNextPerson()
    {
        if (queue.Count == 0)
            throw new InvalidOperationException("No one in the queue.");

        Person person = queue.Dequeue();

        if (person.Turns > 0)
        {
            // Decrement turns immediately
            person.Turns--;

            // Re-enqueue if still has turns
            if (person.Turns > 0)
                queue.Enqueue(person);
        }
        else
        {
            // Infinite turns → always re-enqueue
            queue.Enqueue(person);
        }

        return person;
    }

    // Property to get current queue length
    public int Length => queue.Count;
}
