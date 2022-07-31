using System.Collections.Generic;

namespace Core.DataStructures.Graph;

public class Graph<TValue>
{
    public List<GraphNode<TValue>> Nodes { get; private set; }

    public void Add(GraphNode<TValue> node)
    {
        Nodes.Add(node);
    }

    public void Reset()
    {
        foreach (var node in Nodes)
        {
            node.Reset();
        }
    }
}
