// Simple graph implementation.

// We must subclass "CustomStringConvertible" for our description var method to take effect.
class GraphNode: CustomStringConvertible {
  public var value: Any?;
  public var adjacent: [GraphNode] = [];
  public var marked = false;

  init(value: Any) {
    self.value = value;
  }

  public func addChild(node: GraphNode) -> Void {
    self.adjacent.append(node);
  }

  // Swift version of java toString override.
  public var description: String {
    var retStr = "GraphNode: \(self.value ?? "nil")"
    if (self.adjacent.count > 0) {
      retStr = "\(retStr)\n^adjacent:\n"
      for i in 0...(self.adjacent.count - 1) {
        retStr = "\(retStr)- GraphNode: \(self.adjacent[i].value ?? "nil")\n"
      }
    }
    return retStr;
  }
}

class Graph: CustomStringConvertible {
  public var nodes: [GraphNode] = [];

  public var description: String {
    var retStr = "";
    for node in self.nodes {
      retStr = "\(retStr)\(node.description)\n"
    }
    return retStr;
  }
}
