# Definition of node states.
node_states = {
    'unvisited': -1,
    'visiting': 0,
    'visited': 1
}

# Node class that we will search on.
class Node:
    def __init__(self, value, edges = []):
        self.value = value
        self.edges = edges
        self.state = node_states.get('unvisited')