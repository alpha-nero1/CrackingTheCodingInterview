using System;
using System.Text;
using System.Collections.Generic;

namespace Core.DataStructures {

	/// <summary>
	/// HashTable implementation (dictionary)
	/// </summary>
	public class HashTable<T> {

		class ChainNode<T> {
			public string Key { get; set; };
			public int InsertionCountRef { get; set; };
			public T Value { get; set; };

			public ChainNode Next { get; }

			public ChainNode(string key, T value) {
				Key = key;
				Value = value;
				InsertionCountRef = insertionCountRef;
			}

			public void SetNext(ChainNode next) {
				Next = next;
			}
		}

		private static int INITIAL_ARRAY_SIZE = 1000;

		// We would use dynamic instead of object if we cared about accessing
		// instance methods on the arrays.
		private LinkedList<ChainNode<T>>[] entries = new LinkedList<ChainNode<T>>[Hashtable.INITIAL_ARRAY_SIZE];

		private int _collisionCount = 0;

		private int _insertionCount = 0;

		public Hashtable(IEnumerable<KeyValuePair<string, T>> keyValuePairs) {
			if (keyValuePairs.Count() > 0) {
				for (var i = 0; i < keyValuePairs.Count(); i++) {
					Set(keyValuePairs[i].Key, keyValuePairs[i].Value);
				}
			}
		}

		public void Set(string key, T value) {
			if (String.IsNullOrWhiteSpace(key)) return;

			int hashIndex = Hash(key, this.entries.Length);
			
			_insertionCount += 1;
			var newNode = new ChainNode<T>(key, value, _insertionCount);
			// Set the value in its chain.
			LinkedList<ChainNode> chain = this.entries[hashIndex];
			if (chain != null) {
				// If we find our item in the chain, replace value.
				ChainNode existingNode = FindNodeByKey(key, chain);
				if (existingNode != null) {
					chain.Remove(existingNode);
				} else if (chain.Count > 0) {
					// Our node might not exist but lets check if collision count needs to increment.
					_collisionCount += 1;
				}
			} else {
				chain = new LinkedList<ChainNode>();
				this.entries[hashIndex] = chain;
			}
			if (chain.Last != null && chain.Last.Value != null) {
				ChainNode last = chain.Last.Value;
				if (last != null) {
					last.setNext(newNode);
				}
			}
			chain.AddLast(newNode);
		}

		public T Get(string key) {
			if (key != null) {
				int hashIndex = Hash(key, this.entries.Length);
				LinkedList<ChainNode> chain = this.entries[hashIndex];
				foreach (ChainNode node in chain) {
					if ((string) node.chain[0] == key) {
						return node.chain[1];
					}
				}
			}
			return null;
		}

		public bool Has(string key) {
			return Get(key) != null;
		}

		public void Remove(string key) {
			if (String.IsNullOrWhiteSpace(key)) return;

			int hashIndex = Hash(key, this.entries.Length);
			LinkedList<ChainNode> chain = this.entries[hashIndex];
			if (chain == null) return;

			ChainNode nodeToRemove = FindNodeByKey(key, chain);
			if (nodeToRemove != null) chain.Remove(nodeToRemove);
		}

		public override string ToString() { // ToString method for object representation. ✅
			string str = "{\n";
			bool hasPassedFirst = false;
			for (var i = 0; i < this.entries.Length; i++) {
				LinkedList<ChainNode> chain = this.entries[i];
				if (chain != null && chain.First != null) {
					ChainNode node = chain.First.Value;
					while (node != null) {
						string chainItemKey = (string) node.chain[0];
						object chainItemValue = node.chain[1];
						System.Type valueType = chainItemValue.GetType();
						if (hasPassedFirst) {
							// We are not at the very last entry.
							str = $"{str},\n";
						}
						if (valueType.Equals(typeof(int))) {
							str = $"{str}  \"{chainItemKey}\" : {chainItemValue}";
						} else {
							str = $"{str}  \"{chainItemKey}\" : \"{chainItemValue}\"";
						}
						node = node.next;
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

		// Our hash function...
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

		private int FindIndexOfKeyInChain(string key, object[,] chain) {
			if (chain != null && chain.Length > 0) {
				for (var i = 0; i < chain.Length; i++) {
					if ((string) chain[i, 0] == key) {
						return i;
					}
				}
			}
			return -1;
		}

		private ChainNode FindNodeByKey(string key, LinkedList<ChainNode> chain) {
			ChainNode node = chain.First.Value;
			while (node != null) {
				string nodeKey = (string) node.chain[0];
				if (nodeKey == key) {
					return node;
				}
				node = node.next;
			}
			return null;
		}

		#endregion
	}
}