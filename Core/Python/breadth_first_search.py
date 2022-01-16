from node import Node, node_states

# Breadth first search algorithm.
def bfs(node_start, node_end, visit_func = None):
    if (node_start == node_end): return True
    queue = []

    # Mark first node as visiting.
    node_start.state = node_states.get('visiting')
    queue.append(node_start)

    next_node = None
    # Now we begin the while logic...
    while (len(queue) > 0):
        # Remove first item from the queue (or next item).
        next_node = queue.pop(0)
        next_node.state = node_states['visiting']
        # If we have passed in a function and it is callable, do the extra logic...
        if (callable(visit_func)): visit_func(next_node)
        # Sanity check before continuing on the node.
        if (next_node == None): continue
        # Loop the adjacent nodes on the next node.
        for adj_node in next_node.edges:
            # If we visited the node, skip, it's already been dealt with.
            if (adj_node.state == node_states['visited'] or adj_node.state == node_states['visiting']): continue;
            # However if this node is the end then let's return, we're done searching.
            if (adj_node == node_end): return True
            # Otherwise append it to the queue for IT'S adjacents to be evaluated.
            queue.append(adj_node)
        next_node.state = node_states['visited']

    # No path found :(
    return False


# Graph
root_node = Node(1)
end_node = Node(10)
root_node.edges.append(Node(2, [Node(3, [Node(4), Node(5), Node(6), Node(7, [end_node]), Node(8, [Node(9, [root_node])])])]))


# Bombs away...
bfs(root_node, end_node, lambda node: print(f'visiting node {node.value}'))