using System.Collections.Generic;

namespace Core.DataStructures.Queue;

public interface IQueue<TData> : IEnumerable<TData>
{
    int Count { get; }
    void Enqueue(TData value);
    TData Dequeue();
    TData Peek();
}
