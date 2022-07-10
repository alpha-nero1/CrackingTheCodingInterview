using System.Collections.Generic;

namespace Core.DataStructures
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;

        public LinkedList() {}

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(_head);
        }

    }

    class LinkedListEnumerator<T> : IEnumerator<T>
    {
        private Node<T> _head;

        public LinkedListEnumerator(Node<T> head)
        {
            _head = head;
        }
    }

    class Node<T> {
		public T Value { get; set; }

		public Node<T> Next { get; private set; }

		public Node(T value) {
			Value = value;
		}

		public void SetNext(Node<T> next) {
			Next = next;
		}
	}
}