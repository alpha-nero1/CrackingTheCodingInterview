class GraphNode<T> {
  public T value;
  public Object[] adjacent = new Object[1];

  GraphNode(T value) {
    this.value = value;
  }

  void addAdjacent(GraphNode<T> node) {
    this.adjacent = ArrayUtils.Append(node, this.adjacent);
  }
}

class BinaryNode {
  public int value;
  public BinaryNode left;
  public BinaryNode right;

  BinaryNode(int value) {
    this.value = value;
  }

  public String toString() {
    return this.value + " (l: " + this.leftValue() + ", r: " + this.rightValue() + ")";
  }

  public String leftValue() {
    if (this.left != null) {
      return "" + this.left.value;
    }
    return "";
  }

  public String rightValue() {
    if (this.right != null) {
      return "" + this.right.value;
    }
    return "";
  }
}

class Graph<T> {
  public T root;
}