# Depth-first search (DFS)

```
void search(Node root) {
  if (root == null) {
    return;
  }
  visit(root); // exec some visting code if need be.
  root.visited = true;
  for each (Node n in root.adjacent) {
    if (n.visited == false) {
      search(n);
    }
  }
}
```

# Breadth-first search (BFS)
BFS MUST use a queue
```
// The dequeue and later enqueue if unmarked found and vice versa will keep our search
// In just the next layer, then the next, then next and so on because the root is 
// being mixed in the same queue as the adjacent nodes and the !isEmpty keeps the
// party going.
void search(Node root) {
  Queue queue = new Queue();
  root.marked = true;
  queue.enqueue(root); // Add root to end of queue.
  while (!queue.isEmpty()) {
    Node qn = queue.dequeue(); // Take a node out of the queue.
    visit(qn); // Visit the node do whatever logic.
    for each (Node n in qn.adjacent) { // Cool foreach adds ALL adjacent to queue so they can later be worked through.
      if (n.marked == false) {
        n.marked = true;
        queue.enqueue(n)
      }
    }
  }
}
```