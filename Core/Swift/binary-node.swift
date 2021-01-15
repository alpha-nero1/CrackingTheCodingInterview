// Binary node class definition.
class BinaryNode: CustomStringConvertible {

  public var value: Int;

  public var left: BinaryNode?;

  public var right: BinaryNode?;

  init(value: Int) {
    self.value = value;
  }

  public func leftValue() -> String {
    if let leftNode = self.left {
      return String(leftNode.value);
    }
    return "nil";
  }

  public func rightValue() -> String {
    if let rightNode = self.right {
      return String(rightNode.value);
    }
    return "nil";
  }

  // Getter value prop func style.
  public var description: String {
    let stringValue = String(self.value)
    return "[BinaryNode value:\(stringValue), l:\(self.leftValue()), r:\(self.rightValue())]"
  }
}
