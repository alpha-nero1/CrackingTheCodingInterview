// Linked list implementation.

class LinkedList {
  constructor() {
    // First node is called the head.
    this.head = null;
    this.idCount = 0;
  }

  static DeleteNode(prev, next) {
    if (prev) {
      prev.next = next;
    }
  }

  addNode(newNode) {
    this.idCount = this.idCount + 1;
    newNode.idCount = this.idCount;
    if (this.head) {
      let node = this.head;
      while (node.next != null) {
        node = node.next;
      }
      // By this point we are at last node of the chain.
      node.next = newNode;
      newNode.prev = node;
    } else {
      this.head = newNode;
    }
    return newNode;
  }

  add(value) {
    const newNode = new ListNode(value);
    return this.addNode(newNode);
  }

  addBatch(...values) {
    if (values && values.length) {
      values.forEach(val => {
        this.add(val);
      })
    }
  }

  delete(value) {
    if (this.head) {
      let node = this.head;
      if (node.value === value) {
        this.head = node.next; // moved head...
      }
      while (node.next !== null) {
        if (node.next.value === value) {
          node.next = node.next.next;
          // Standard deletion, head did not change.
          return;          
        }
        node = node.next;
      }
    }
  }

  toString() {
    let node = this.head;
    let str = ''
    while (node) {
      str += ` -> (id: ${node.id}: value: ${node.value})`
      node = node.next;
    }
    return str;
  }
}

class ListNode {
  constructor(value) {
    this.id = null;
    this.next = null;
    this.value = value;
    this.prev = null;
  }

  appendNewNodeToTail(value) {
    endNode = new ListNode(value);
    const node = this;
    while (node.next !== null) {
      node = node.next;
    }
    node.next = endNode
  }

  toString() {
    return `(id: ${this.id}: value: ${this.value})`;
  }
}

module.exports = {
  LinkedList,
  ListNode
}