using System.Collections;
using System.Collections.Generic;
using LL = Core.DataStructures.LinkedList;

namespace Core.DataStructures.Queue;

/// <summary>
/// Queues work off of the FIFO principle, First In First Out.
/// </summary>
public class Queue<TData> : IQueue<TData>
{
    public int Count => _queue.Count;
    public LL.ILinkedList<TData> _queue { get; set; } = new LL.LinkedList<TData>();

    public TData Dequeue()
    {
        if (_queue.Count == 0) return default;
        var first = _queue[0];
        _queue.RemoveAt(0);
        return first;
    }

    public void Enqueue(TData value)
    {
        _queue.Add(value);
    }

    public TData Peek()
    {
        if (_queue.Count == 0) return default;
        return _queue[0];
    }

    // Expose the enumerator of the inner queue.
    public IEnumerator<TData> GetEnumerator()
    {
        return _queue.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _queue.GetEnumerator();
    }
}