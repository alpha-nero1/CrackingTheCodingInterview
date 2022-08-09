using Core.DataStructures.Stack;
using Xunit;

namespace Testing;

public class StackTests
{
    [Fact]
    public void LifoWorks()
    {
        var stack = new Stack<int>();

        stack.Enqueue(1);
        stack.Enqueue(2);
        stack.Enqueue(3);
        stack.Enqueue(4);

        Assert.True(stack.Peek() == 4, "Peek did not find correct element");
        Assert.True(stack.Count == 4, "Stack has incorrect value count");

        var next = stack.Dequeue();

        Assert.True(next == 4, "Lifo failed");
        Assert.True(stack.Count == 3, "Count failed");
    }
}