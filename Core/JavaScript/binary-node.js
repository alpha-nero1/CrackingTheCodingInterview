class BinaryNode {
  constructor(value) {
    this.value = value;
    this.left = null;
    this.right = null;
    this.height = 0;
  }

  setRight(node) {
    this.right = node;
    this.right.height = this.height + 1;
  }

  setLeft(node) {
    this.left = node;
    this.left.height = this.height + 1;
  }

  leftValue() {
    if (this.left) {
      return "" + this.left.value;
    }
    return "";
  }

  rightValue() {
    if (this.right) {
      return "" + this.right.value;
    }
    return "";
  }

  toString() {
    return `[BinaryNode value:${this.value}, left:${this.leftValue()}, right:${this.rightValue()}]`;
  }
}

module.exports = { BinaryNode }
