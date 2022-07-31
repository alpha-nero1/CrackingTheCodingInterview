using System.Collections.Generic;

namespace Core.DataStructures.Graph;

public class GraphNode<TValue>
{
    public bool IsVisited { get; private set; }
    public TValue Value { get; set; }
    public List<GraphNode<TValue>> Adjacent { get; private set; } = new List<GraphNode<TValue>>();

    public GraphNode() {}

    public GraphNode(TValue value) {
        Value = value;
    }

    public GraphNode(TValue value, IEnumerable<GraphNode<TValue>> adjacent) {
        Value = value;
        Adjacent = new List<GraphNode<TValue>>(adjacent);
    }

    public void AddAdjacent(GraphNode<TValue> n, bool addReciprocal = true)
    {
        Adjacent.Add(n);
        if (addReciprocal) n.AddAdjacent(this);
    }

    /// <summary>
    /// Get adhacent values that have not yet been visited.
    /// </summary>
    public List<GraphNode<TValue>> GetAdjacent()
    {
        var ret = new List<GraphNode<TValue>>();
        foreach (var adj in Adjacent)
        {
            if (!adj.IsVisited) ret.Add(adj);
        }
        return ret;
    }

    public void SetIsVisited()
    {
        IsVisited = true;
    }

    public void Reset()
    {
        IsVisited = false;

        foreach (var adj in Adjacent)
        {
            if (adj.IsVisited) adj.Reset();
        }
    }
}