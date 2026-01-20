using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a person in the queue with a name and number of turns.
/// Turns <= 0 are considered infinite.
/// </summary>
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

/// <summary>
/// Maintains a circular queue of people. When people are added, they go to the
/// back of the queue. When GetNextPerson is called, the next person is returned
/// and possibly re-added depending on their remaining turns.
/// </summary>
public class TakingTurnsQueue
{
    private readonly Queue<Person> _people = new();

    /// <summary>
    /// Gets the current number of people in the queue
    /// </summary>
    public int Length => _people.Count;

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining (0 or less = infinite)</param>
    public void AddPerson(string name, int turns)
    {
        _people.Enqueue(new Person(name, turns));
    }

    /// <summary>
    /// Get the next person in the queue and return them.
    /// The person is re-added if they still have turns remaining or
    /// if they have infinite turns.
    /// Throws an exception if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Infinite turns
            _people.Enqueue(person);
        }
        else
        {
            person.Turns--;

            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }

        return person;
    }

    /// <summary>
    /// String representation of the queue
    /// </summary>
    public override string ToString()
    {
        return string.Join(", ", _people.Select(p => p.Name));
    }
}
