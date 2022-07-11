using System.Collections.Generic;
using System.Collections;

namespace Core.DataStructures.LinkedList
{
    /// <summary>
    /// Custom C# linked list implementation.
    /// </summary>
    public interface ILinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Total count of elements in the linked list.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Add an item to the list.
        /// </summary>
        void Add(T value);

        /// <summary>
        /// Remove an item from the list.
        /// </summary>
        T Remove(T value);

        /// <summary>
        /// Get last item in the list.
        /// </summary>
        T Last();

        /// <summary>
        /// Get first item in the list.
        /// </summary>
        T First();
    }
}