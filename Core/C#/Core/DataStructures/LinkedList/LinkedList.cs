using System.Collections.Generic;
using System.Collections;
using System;

namespace Core.DataStructures.LinkedList
{
    public class LinkedList<T> : ILinkedList<T>
    {
        private Node<T> _head;
        public int Count { get; private set; }

        public LinkedList() {}

        public T this[int index]
		{
			get {
                var node = GetAtIndex(index);
                if (node == null) throw new IndexOutOfRangeException();
                return node.Value;
            }

            set {
                var node = GetAtIndex(index);
                if (node == null) throw new IndexOutOfRangeException();
                node.Value = value;
            }
		}

        public T First()
        {
            if (_head == null) return default(T);
            return _head.Value;
        }

        public T Last()
        {
            var tail = GetTail();
            if (tail == null) return default(T);
            return tail.Value;
        }

        public void Add(T value)
        {
            Count += 1;
            var tail = GetTail();
            var newNode = new Node<T>(value);

            if (tail == null)
            {
                _head = newNode;
                return;
            }

            tail.Next = newNode;
        }

        public T Remove(T value)
        {
            var current = _head;
            Node<T>? prev = null;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    var next = current.Next;

                    // If none before set head as the next node in the chain.
                    if (prev == null)
                    {
                        _head = next;
                        Count -= 1;
                        return value;
                    }

                    // If none in front then set null to the previous next ref.
                    if (next == null)
                    {
                        prev.Next = null;
                        Count -= 1;
                        return value;
                    }

                    // Else the next of prev = next
                    prev.Next = next;
                    Count -= 1;

                    return value;
                }
                current = current.Next;
                prev = current;
            }

            return default;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(_head);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Must implement this because IEnumerator<T> extends IEnumerator.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Node<T> GetTail()
        {
            var current = _head;
            while (current != null)
            {
                if (current.Next == null) return current;
                current = current.Next;
            }
            return current;
        }

        private Node<T> GetAtIndex(int i)
        {
            var current = _head;
            int count = 0;
            while (current != null)
            {
                if (count == i) return current;
                current = current.Next;
                count += 1;
            }
            return current;
        }
    }

    class LinkedListEnumerator<T> : IEnumerator<T>
    {
        private Node<T> _head;
        private Node<T> _current;
        bool _readFirst = false;
        private bool disposedValue = false;

        public LinkedListEnumerator(Node<T> head)
        {
            _head = head;
            _current = head;
        }

        public bool MoveNext()
        {
            if (!_readFirst)
            {
                _readFirst = true;
                return true;
            }
            _current = _current.Next;
            return _current != null;
        }

        public void Reset()
        {
            _current = _head;
        }

        T IEnumerator<T>.Current
        {
            get
            {
                return Current;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return (object) Current;
            }
        }

        public T Current
        {
            get
            {
                return _current.Value;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            _head = null;
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

         ~LinkedListEnumerator()
        {
            Dispose(false);
        }
    }

    class Node<T> {
		public T Value { get; set; }

		public Node<T> Next { get; set; }

		public Node(T value) {
			Value = value;
		}
	}
}