using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Core.DataStructures {

	public class HashTable<T> : IHashTable<T> {
		private static int INITIAL_ARRAY_SIZE = 1000;

		private LinkedList<ChainNode<T>>[] _entries = new LinkedList<ChainNode<T>>[INITIAL_ARRAY_SIZE];

		private int _collisionCount = 0;

		private int _insertionCount = 0;

		public HashTable() {}

		public HashTable(IEnumerable<KeyValuePair<string, T>> keyValuePairs) {
			if (keyValuePairs.Count() > 0) {
				foreach (var keyValuePair in keyValuePairs)
				{
					Set(keyValuePair.Key, keyValuePair.Value);
				}
			}
		}

		// This property def allows access via [] syntax.
		public T this[string key]
		{
			get { return Get(key); }

			set { Set(key, value); }
		}

        public T Get(string key) {
			if (key != null) {
				int hashIndex = Hash(key, _entries.Length);
				LinkedList<ChainNode<T>> chain = _entries[hashIndex];
				foreach (ChainNode<T> node in chain) {
					if (node.Key == key) return node.Value;
				}
			}
			return default;
		}

        public IEnumerable<T> Values() => Items().Select(x => x.Value);

		public IEnumerable<string> Keys() => Items().Select(x => x.Key);

        public bool Has(string key) {
			return !EqualityComparer<T>.Default.Equals(Get(key), default(T));
		}

		public void Set(string key, T value) {
			if (String.IsNullOrWhiteSpace(key)) return;

			int hashIndex = Hash(key, _entries.Length);

			_insertionCount += 1;
			var newNode = new ChainNode<T>(key, value, _insertionCount);
			// Set the value in its chain.
			LinkedList<ChainNode<T>> chain = _entries[hashIndex];

			if (chain != null) {
				// If we find our item in the chain, replace value.
				ChainNode<T> existingNode = FindNodeByKey(key, chain);
				if (existingNode != null) {
					chain.Remove(existingNode);
				} else if (chain.Count > 0) {
					// Our node might not exist but lets check if collision count needs to increment.
					_collisionCount += 1;
				}
			} else {
				chain = new LinkedList<ChainNode<T>>();
				_entries[hashIndex] = chain;
			}
			if (chain.Last != null && chain.Last.Value != null) {
				ChainNode<T> last = chain.Last.Value;
				if (last != null) {
					last.SetNext(newNode);
				}
			}
			chain.AddLast(newNode);
		}

		public void Remove(string key) {
			if (String.IsNullOrWhiteSpace(key)) return;

			int hashIndex = Hash(key, _entries.Length);
			LinkedList<ChainNode<T>> chain = _entries[hashIndex];
			if (chain == null) return;

			ChainNode<T> nodeToRemove = FindNodeByKey(key, chain);
			if (nodeToRemove != null) chain.Remove(nodeToRemove);
		}

		public void Clear()
		{
			_entries = new LinkedList<ChainNode<T>>[INITIAL_ARRAY_SIZE];
			_collisionCount = 0;
			_insertionCount = 0;
		}

		public override string ToString() {
			string str = "{\n";
			bool hasPassedFirst = false;
			for (var i = 0; i < _entries.Length; i++) {
				LinkedList<ChainNode<T>> chain = _entries[i];
				if (chain != null && chain.First != null) {
					ChainNode<T> node = chain.First.Value;
					while (node != null) {
						string chainItemKey = node.Key;
						T chainItemValue = node.Value;
						System.Type valueType = chainItemValue.GetType();
						if (hasPassedFirst) {
							// We are not at the very last entry.
							str = $"{str},\n";
						}
						if (valueType.Equals(typeof(int))) {
							str = $"{str}  \"{chainItemKey}\": {chainItemValue}";
						} else {
							str = $"{str}  \"{chainItemKey}\": \"{chainItemValue}\"";
						}
						node = node.Next;
						if (!hasPassedFirst) {
							hasPassedFirst = true;
						}
					}
				}
			}
			str = $"{str}\n}}";
			return str;
		}

		#region Private helper methods.

		private int Hash(string key, int max) {
			long totalHash = 0;
			int prime = 17;
			if (key != null && key.Length > 0) {
				byte[] charCodes = Encoding.ASCII.GetBytes(key);
				for (var i = 0; i < charCodes.Length; i++) {
					// Build the hash.
					totalHash += (prime * totalHash + charCodes[i]);
				}
				long res = totalHash % max;
				return (int) res;
			}
			return -1;
		}

		private ChainNode<T> FindNodeByKey(string key, LinkedList<ChainNode<T>> chain) {
			if (chain == null || chain.First == null) return null;
			ChainNode<T> node = chain.First.Value;
			while (node != null) {
				string nodeKey = node.Key;
				if (nodeKey == key) return node;
				node = node.Next;
			}
			return null;
		}

		private IEnumerable<KeyValuePair<string, T>> Items()
		{
			// Note, brute force approach for now, must be a better way...
			var keys = new List<KeyValuePair<string, T>>();
			var allItems = _entries.Where(x => x != null && x.Count() > 0);
			foreach (var item in allItems)
			{
				foreach (var node in item)
				{
					keys.Add(new KeyValuePair<string, T>(node.Key, node.Value));
				}
			}
			return keys;
		}

		#endregion
	}

	class ChainNode<T> {
		public string Key { get; set; }
		public int InsertionCountRef { get; set; }
		public T Value { get; set; }

		public ChainNode<T> Next { get; private set; }

		public ChainNode(string key, T value, int insertionCountRef) {
			Key = key;
			Value = value;
			InsertionCountRef = insertionCountRef;
		}

		public void SetNext(ChainNode<T> next) {
			Next = next;
		}
	}
}