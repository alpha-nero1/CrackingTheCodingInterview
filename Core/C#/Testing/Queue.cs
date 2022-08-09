using Core.DataStructures.Queue;
using Xunit;

namespace Testing;

public class QueueTests
{
    [Fact]
    public void FifoWorks()
    {
        var q = new Queue<int>();

        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        q.Enqueue(4);

        Assert.True(q.Peek() == 1, "Peek did not find correct element");
        Assert.True(q.Count == 4, "queue has incorrect value count");

        var next = q.Dequeue();

        Assert.True(next == 1, "Fifo failed");
        Assert.True(q.Count == 3, "Count failed");
    }
}