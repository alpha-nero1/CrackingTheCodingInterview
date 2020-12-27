// Tree node class.

class TreeNode {
  constructor(parent, value, od) {
    this._id = id;
    this._parent = parent;
    this._value = value;
    this._children = [];
  }

  getParent() {
    return this._parent;
  }

  setParent(parent) {
    this._parent = parent;
  }

  getValue() {
    return this._value;
  }

  setValue(value) {
    this._value = value;
  }

  getChildren() {
    return this._children;
  }

  setChildren(children) {
    this._children = children;
  }

  addChild(childNode) {
    this._children.push(childNode);
  }

  removeChild(index) {
    this._children = this._children.filter((c, i) => i !== index);
  }
}