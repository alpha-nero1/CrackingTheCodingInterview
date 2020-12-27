class StackList {
  constructor() { 
    this.last = null;
    // Record of minimums.
    this._minArr = [];
    this._count = 0;
  }

  push(value) {
    const newNode = new Node(value);
    if (!this.last) {
      this.last = newNode;
    } else {
      const oldLast = this.last;
      oldLast.next = newNode;
      this.last = newNode;
      this.last.prev = oldLast;
    }
    if (!this._minArr.length || value < this._minArr[this._minArr.length - 1]) {
      this._minArr.push(value);
    }
    this._count++;
  }

  min() {
    return this._minArr[this._minArr.length - 1];
  }

  pop() {
    if (this.last.value === this.min()) {
      this._minArr.pop();
    }
    this.last = this.last.prev;
    this._count--;
  }

  count() {
    return this._count;
  }

  peek() {
    return this.last;
  }

  isEmpty() {
    return !!this.last
  }
}

class Node {
  constructor(value) {
    this.value = value;
    this.next = null;
    this.prev = null;
  }
}

module.exports = { StackList, Node }