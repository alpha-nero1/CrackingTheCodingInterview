/*
    Breadth first search is the more elaborate of the two graph seareching methods.
    It works by not invoking the search right away but making adjacent nodes wait in
    a queue. It let's us search level by level.

    We look at the first node, add its adjacent to the queue, then we look
    node by node adding it's adjacent to the end of the queue.
*/

using System;
using System.Collections.Generic;
using Core.DataStructures.Graph;

namespace Core.Searching;

public static class BFSExtensions
{
    /// <summary>
    /// Breadth first search a graph node.
    /// </summary>
    public static bool BreadthFirstSearch<TValue>(this GraphNode<TValue> node, Func<GraphNode<TValue>, bool> callback)
    {
        var queue = new List<GraphNode<TValue>>();

        queue.Add(node);

        while (queue.Count > 0)
        {
            // Dequeue.
            var next = queue[0];
            queue.RemoveAt(0);

            bool stop = callback(next);
            // If stop, back out.
            if (stop) return stop;

            // Loop adjacent of the next.
            foreach (var adj in next.GetAdjacent())
            {
                // Extra precaution although GetAdjacent() will not return
                // any visited nodes.
                if (adj.IsVisited) continue;
                // If adjacent are all added into a queue instead of directly
                // invoked, then we end up iterating level by level...
                queue.Add(adj);
            }
        }

        return false;
    }
}

/*
Example input =
(
    1 -> [
        2, -> [
            3,
            4,
            5
        ]
        6, -> [
            7,
            8
        ]
        9 -> [
            10,
            11,
            12
        ]
    ]

    queue = [1, 2, 6, 9, 3, 4, 5, 7, 8, 10, 11, 12]
)
*/