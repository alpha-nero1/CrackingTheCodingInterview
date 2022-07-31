/*
    Depth first search is the simplest of the two graph searching methods, simply
    keep iterating the adjacent and the search will operate depth first!
*/

using System;
using Core.DataStructures.Graph;

namespace Core.Searching;

public static class DFSExtensions
{
    /// <summary>
    /// Depth first search a graph node.
    /// </summary>
    public static bool DepthFirstSearch<TValue>(this GraphNode<TValue> node, Func<GraphNode<TValue>, bool> callback)
    {
        if (node.IsVisited) return false;
        node.SetIsVisited();

        bool stop = callback(node);
        // If the stop flag was returned, stop the search
        // we got what we are looking for.
        if (stop) return stop;

        foreach (var adj in node.GetAdjacent())
        {
            if (adj.IsVisited) continue;
            bool isFound = DepthFirstSearch(adj, callback);
            if (isFound) return isFound;
        }

        return false;
    }
}