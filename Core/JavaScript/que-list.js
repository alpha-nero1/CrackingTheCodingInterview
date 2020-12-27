class QueList {

  constructor() { 
    this.first = null;
    this.last = null;
  }

  add(value) {
    const newNode = new Node(value);
    if (this.first && this.last) {
      // We have a list.
      this.last.next = newNode;
      this.last = newNode

    } else {
      this.last = newNode;
      this.first = newNode;
    }
  }

  remove() {
    let nextInLine = this.first.next;
    this.first = nextInLine;
  }

  peek() {
    return this.first;
  }

  isEmpty() {
    return !!this.first
  }
}

class Node {
  constructor(value) {
    this.value = value;
    this.next = null;
    this.prev = null;
  }
}

module.exports = { QueList, Node }