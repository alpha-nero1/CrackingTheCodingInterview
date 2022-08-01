using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Core.DataStructures.HashTable;

public class HashTable<TKey, TData> : IHashTable<TKey, TData>
{
    private static int INITIAL_ARRAY_SIZE = 1000;

    private LinkedList<ChainNode<TKey, TData>>[] _entries = new LinkedList<ChainNode<TKey, TData>>[INITIAL_ARRAY_SIZE];

    private int _collisionCount = 0;

    private int _insertionCount = 0;

    public HashTable() {}

    public HashTable(IEnumerable<KeyValuePair<TKey, TData>> keyValuePairs) {
        if (keyValuePairs.Count() > 0) {
            foreach (var keyValuePair in keyValuePairs)
            {
                Set(keyValuePair.Key, keyValuePair.Value);
            }
        }
    }

    // This property def allows access via [] syntax.
    public TData this[TKey key]
    {
        get { return Get(key); }

        set { Set(key, value); }
    }

    public TData Get(TKey key) {
        if (key != null) {
            int hashIndex = Hash(key, _entries.Length);
            LinkedList<ChainNode<TKey, TData>> chain = _entries[hashIndex];
            foreach (ChainNode<TKey, TData> node in chain) {
                if (EqualityComparer<TKey>.Default.Equals(key, node.Key)) return node.Value;
            }
        }
        return default;
    }

    public IEnumerable<TData> Values() => Items().Select(x => x.Value);

    public IEnumerable<TKey> Keys() => Items().Select(x => x.Key);

    public bool Has(TKey key) {
        return !EqualityComparer<TData>.Default.Equals(Get(key), default(TData));
    }

    public void Set(TKey key, TData value) {
        if (key == null) return;

        int hashIndex = Hash(key, _entries.Length);

        _insertionCount += 1;
        var newNode = new ChainNode<TKey, TData>(key, value, _insertionCount);
        // Set the value in its chain.
        LinkedList<ChainNode<TKey, TData>> chain = _entries[hashIndex];

        if (chain != null) {
            // If we find our item in the chain, replace value.
            ChainNode<TKey, TData> existingNode = FindNodeByKey(key, chain);
            if (existingNode != null) {
                chain.Remove(existingNode);
            } else if (chain.Count > 0) {
                // Our node might not exist but lets check if collision count needs to increment.
                _collisionCount += 1;
            }
        } else {
            chain = new LinkedList<ChainNode<TKey, TData>>();
            _entries[hashIndex] = chain;
        }
        if (chain.Last != null && chain.Last.Value != null) {
            ChainNode<TKey, TData> last = chain.Last.Value;
            if (last != null) {
                last.SetNext(newNode);
            }
        }
        chain.AddLast(newNode);
    }

    public void Remove(TKey key) {
        if (key == null) return;

        int hashIndex = Hash(key, _entries.Length);
        LinkedList<ChainNode<TKey, TData>> chain = _entries[hashIndex];
        if (chain == null) return;

        ChainNode<TKey, TData> nodeToRemove = FindNodeByKey(key, chain);
        if (nodeToRemove != null) chain.Remove(nodeToRemove);
    }

    public void Clear()
    {
        _entries = new LinkedList<ChainNode<TKey, TData>>[INITIAL_ARRAY_SIZE];
        _collisionCount = 0;
        _insertionCount = 0;
    }

    public override string ToString() {
        string str = "{\n";
        bool hasPassedFirst = false;
        for (var i = 0; i < _entries.Length; i++) {
            LinkedList<ChainNode<TKey, TData>> chain = _entries[i];
            if (chain != null && chain.First != null) {
                ChainNode<TKey, TData> node = chain.First.Value;
                while (node != null) {
                    TKey chainItemKey = node.Key;
                    TData chainItemValue = node.Value;
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

    private int Hash(TKey key, int max)
    {
        if (key is string) return HashString((string)(object) key, max);
        long hash = 17 * key.GetHashCode();
        return (int) hash % max;
    }

    // Just to flex that we understand how the hashing works...
    private int HashString(string key, int max) {
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

    private ChainNode<TKey, TData> FindNodeByKey(TKey key, LinkedList<ChainNode<TKey, TData>> chain) {
        if (chain == null || chain.First == null) return null;
        ChainNode<TKey, TData> node = chain.First.Value;
        while (node != null) {
            TKey nodeKey = node.Key;
            if (EqualityComparer<TKey>.Default.Equals(nodeKey, key)) return node;
            node = node.Next;
        }
        return null;
    }

    private IEnumerable<KeyValuePair<TKey, TData>> Items()
    {
        // Note, brute force approach for now, must be a better way...
        var keys = new List<KeyValuePair<TKey, TData>>();
        var allItems = _entries.Where(x => x != null && x.Count() > 0);
        foreach (var item in allItems)
        {
            foreach (var node in item)
            {
                keys.Add(new KeyValuePair<TKey, TData>(node.Key, node.Value));
            }
        }
        return keys;
    }

    public IEnumerator<TKey> GetEnumerator()
    {
        return Keys().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Keys().GetEnumerator();
    }

    #endregion
}

/// <summary>
/// Extension class assuming that keys are string.
/// </summary>
public class HashTable<TData> : HashTable<string, TData> {}

/// <summary>
/// Chain node class keeeping reference to our inserted elements.
/// </summary>
class ChainNode<TKey, TData> {
    public TKey Key { get; set; }
    public int InsertionCountRef { get; set; }
    public TData Value { get; set; }

    public ChainNode<TKey, TData> Next { get; private set; }

    public ChainNode(TKey key, TData value, int insertionCountRef) {
        Key = key;
        Value = value;
        InsertionCountRef = insertionCountRef;
    }

    public void SetNext(ChainNode<TKey, TData> next) {
        Next = next;
    }
}