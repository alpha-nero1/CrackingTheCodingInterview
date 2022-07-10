namespace Core.DataStructures {
	public class Tree {
		private BinaryNode _root;

		public Tree() {}
		public Tree(BinaryNode root) {
			_root = root;
		}

		public void Insert(int value) {
			BinaryNode root = _root;
			if (root == null) {
				_root = new BinaryNode(value);
			} else {
				BinaryNode nextNode = (value <= _root.Value) ? _root.Left : _root.Right;
				while (nextNode != null) {
					nextNode = (value <= nextNode.Value) ? nextNode.Left : nextNode.Right;
				}
				if (value <= nextNode.Value) {
					nextNode.SetLeft(new BinaryNode(value));
				} else {
					nextNode.SetRight(new BinaryNode(value));
				}
			}
		}

		public void Delete() {

		}

		public BinaryNode Find() {
			return _root;
		}

		public BinaryNode GetRandomNode() {
			return _root;
		}
	}
}
