using System.Collections;
using System.Collections.Generic;
using LL = Core.DataStructures.LinkedList;

namespace Core.DataStructures.Stack;

/// <summary>
/// Stacks work off of the LIFO principle, Last In First Out.
/// </summary>
public class Stack<TData> : IStack<TData>
{
    public int Count => _queue.Count;
    public LL.ILinkedList<TData> _queue { get; set; } = new LL.LinkedList<TData>();

    public TData Dequeue()
    {
        if (_queue.Count == 0) return default;
        var last = _queue[Count - 1];
        _queue.RemoveAt(Count - 1);
        return last;
    }

    public void Enqueue(TData value)
    {
        _queue.Add(value);
    }

    public TData Peek()
    {
        if (_queue.Count == 0) return default;
        return _queue[Count - 1];
    }

    public IEnumerator<TData> GetEnumerator()
    {
        return _queue.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _queue.GetEnumerator();
    }
}
