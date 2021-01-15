class QueueNode<T> {
  public var value: T;
  public var next: QueueNode?;
  init(value: T) {
    self.value = value;
  }
}

class Queue<T> {
  public var first: QueueNode<T>?;

  // Remove first in line.
  public func pop() -> T? {
    if (self.first != nil) {
      let tmp = self.first;
      self.first = self.first?.next;
      return tmp!.value;
    }
    return nil;
  }

  public func peek() -> QueueNode<T>? {
    return self.first
  }

  public func add(value: T) -> T? {
    let newNode = QueueNode<T>(value: value);
    if (self.first == nil) {
      self.first = newNode;
      return newNode.value;
    }
    guard var node = self.first else {
      return nil;
    }
    while let next = node.next {
      node = next
      if (next == nil) {
        node.next = newNode;
        return node.next!.value;
      }
    }
    return nil;
  }

  public func isEmpty() -> Bool {
    return self.first == nil;
  }
}