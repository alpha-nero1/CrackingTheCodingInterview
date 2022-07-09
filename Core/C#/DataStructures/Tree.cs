namespace Core {
	class Tree {
		private BinaryNode root;
		public Tree() {}
		public Tree(BinaryNode root) {
			this.root = root;
		}

		public void insert(int value) {
			BinaryNode root = this.root;
			if (root == null) {
				this.root = new BinaryNode(value);
			} else {
				BinaryNode nextNode = (value <= this.root.value) ? this.root.left : this.root.right;
				while (nextNode != null) {
					nextNode = (value <= nextNode.value) ? nextNode.left : nextNode.right;
				}
				if (value <= nextNode.value) {
					nextNode.left = new BinaryNode(value);
				} else {
					nextNode.right = new BinaryNode(value);
				}
			}
		}

		public void delete() {

		}

		public BinaryNode find() {
			return this.root;
		}

		public BinaryNode getRandomNode() {
			return this.root;
		}
	}
}
