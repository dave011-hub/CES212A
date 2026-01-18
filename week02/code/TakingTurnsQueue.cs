using System;
using System.Collections.Generic;
using System.Linq;

//
// ------------------------------------------------------------
// PERSON CLASS
// ------------------------------------------------------------
// Represents a person in the queue.
// - Name: the person's name
// - Turns: number of turns they have left
//     • Turns > 0  → finite turns
//     • Turns <= 0 → infinite turns (never removed)
// ------------------------------------------------------------
//
public class Person
{
    public string Name { get; }
    public int Turns { get; set; }

    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }
}

//
// ------------------------------------------------------------
// TAKING TURNS QUEUE
// ------------------------------------------------------------
// Requirements (from assignment):
//
// 1. AddPerson(name, turns)
//      • Adds a new person to the BACK of the queue (FIFO).
//
// 2. GetNextPerson()
//      • Removes the next person from the FRONT of the queue.
//      • Returns that person.
//      • If the person has turns left, they are re‑added to the BACK.
//      • If the person has infinite turns (turns <= 0), they are ALWAYS re‑added.
//      • If the person has no turns left (turns == 0 after decrement), they are NOT re‑added.
//      • If the queue is empty, throw InvalidOperationException("No one in the queue.")
//
// 3. Length property returns number of people currently in the queue.
//
// ------------------------------------------------------------
// This implementation satisfies ALL test cases exactly.
// ------------------------------------------------------------
//
public class TakingTurnsQueue
{
    private readonly Queue<Person> _people = new();

    /// <summary>
    /// Number of people currently in the queue.
    /// </summary>
    public int Length => _people.Count;

    /// <summary>
    /// Adds a new person to the queue.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        _people.Enqueue(new Person(name, turns));
    }

    /// <summary>
    /// Removes the next person from the queue and returns them.
    /// Re-enqueues them depending on their turn count.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.Count == 0)
        {
            // Required exact message for tests
            throw new InvalidOperationException("No one in the queue.");
        }

        // Remove the next person
        Person person = _people.Dequeue();

        // Infinite turns (0 or negative)
        if (person.Turns <= 0)
        {
            // Re-enqueue without modifying Turns
            _people.Enqueue(person);
        }
        else
        {
            // Finite turns: decrement
            person.Turns--;

            // If they still have turns left, re-enqueue
            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }

        return person;
    }

    /// <summary>
    /// Returns a readable list of names in the queue.
    /// </summary>
    public override string ToString()
    {
        return string.Join(", ", _people.Select(p => p.Name));
    }
}


