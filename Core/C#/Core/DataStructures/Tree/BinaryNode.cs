namespace Core.DataStructures;

/// <summary>
/// Binary node data structure that facilitiates a tree graph.
/// </summary>
public class BinaryNode {
    private int _value;
    private BinaryNode _left;
    private BinaryNode _right;
    private BinaryNode _parent;
    private int _size = 0;

    public BinaryNode Right => _right;
    public BinaryNode Left => _left;
    public int Size => _size;
    public int Value => _value;
    public BinaryNode Parent => _parent;


    public BinaryNode(int value) {
        _value = value;
        _size = 1;
    }

    public void SetParent(BinaryNode parent) {
        _parent = parent;
    }

    public void SetLeft(BinaryNode left) {
        _left = left;
        _left.SetParent(this);
    }

    public void SetRight(BinaryNode right) {
        _right = right;
        _right.SetParent(this);
    }

    public void SetSize(int size) {
        _size = size;
    }

    public BinaryNode GetRandomNode() {
        int leftSize = _left == null ? 0 : _left.Size;
        System.Console.WriteLine($"leftSize: {leftSize}");
        System.Random random = new System.Random();
        int index = random.Next(_size);
        System.Console.WriteLine($"index: {index}");

        if (index < leftSize) return _left.GetRandomNode();
        else if (index == leftSize) return this;
        return _right.GetRandomNode();
    }

    public void Insert(int value) {
        if (value < _value) {
            if (_left == null) {
                _left = new BinaryNode(value);
            } else {
                _left.Insert(value);
            }
        } else {
            if (_right == null) {
                _right = new BinaryNode(value);
            } else {
                _right.Insert(value);
            }
        }
        _size += 1;
    }

    public BinaryNode Find(int value) {
        if (value == _value) return this;
        if (value <= _value) return _left != null ? _left.Find(value) : null;
        if (value > _value) return _right != null ? _right.Find(value) : null;
        return null;
    }

    public bool Delete(int value) {
        BinaryNode nodeToDelete = Find(value);
        if (nodeToDelete == null) return false;
        if (nodeToDelete.Parent == null) return false;

        nodeToDelete.Parent.SetSize(nodeToDelete.Parent.Size - nodeToDelete.Size);
        if (nodeToDelete.Parent.Value >= value) {
            // delete parents left
            nodeToDelete.Parent.SetLeft(null);
        } else if (nodeToDelete.Parent.Value < value) {
            nodeToDelete.Parent.SetRight(null);
        }
        return true;
    }

    public string LeftValue() {
        if (_left == null) return "";
        return _left.Value.ToString();
    }

    public string RightValue() {
        if (_right == null) return "";
        return _right.Value.ToString();
    }

    public override string ToString() {
        string str = "[BinaryNode value:";
        str = $"{str}{_value.ToString()} l:{LeftValue()} r:{RightValue()}]";
        return str;
    }
}
