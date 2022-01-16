from node import Node, node_states

# Depth First Search Implementation:
# Theres only really several main parts to the algorithm
# 1. Start with a recursive func structure
# 2. Visit the node and loop the adjacent nodes visiting them
# 3. Optional: you can make the algo stop when it finds what it is looking for by ONLY returning True
# in the for loop IF the child dfs call found the end, else keep lettting it tick along.
# This ends up working depth first because how the recursive stack works is it will always call
# the first node in the loop and so on as opposed to breadth first which in truth does the same thing but
# it does not visit those nodes it adds them to a queue 'row by row' to be visited.
def dfs(next_node, end_node, visit_func = None):
    next_node.state = node_states['visited']
    if (callable(visit_func)): visit_func(next_node)
    # If we found it, let the parent call know, this will travel all the way up the stack.
    if (next_node == end_node): return True
    
    for adj_node in next_node.edges:
        # If we visited the node, skip, it's already been dealt with.
        if (adj_node.state == node_states['visited'] or adj_node.state == node_states['visiting']): continue;
        # The brilliance of these two lines here is that we ONLY return if dfs found the end node, else
        # let the algo keep ticking along, noice.
        found = dfs(adj_node, end_node, visit_func)
        if (found): return True

    return False

# Just graph building rubbish here...
root_node = Node(1)
end_node = Node(100)

root_node.edges = [
    Node(2, [
        Node(6, [
            Node(22, [
                Node(23, [
                    Node(24, [
                        Node(25)
                    ])
                ])
            ])
        ]),
        Node(7),
        Node(8),
        Node(9, [
            Node(99, [
                Node(999, [
                    end_node
                ])
            ])
        ]),
    ]),
    Node(3, [
        Node(10),
        Node(11),
        Node(12),
        Node(13),
    ]),
    Node(4, [
        Node(14),
        Node(15),
        Node(16),
        Node(17),
    ]),
    Node(5, [
        Node(18),
        Node(19),
        Node(20),
        Node(21),
    ]),
]

# Root dfs call...
dfs(root_node, end_node, lambda node: print(f'visiting node: {node.value}'))