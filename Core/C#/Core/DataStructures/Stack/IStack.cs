using System.Collections.Generic;

namespace Core.DataStructures.Stack;

public interface IStack<TData> : IEnumerable<TData>
{
    int Count { get; }
    void Enqueue(TData value);
    TData Dequeue();
    TData Peek();
}
