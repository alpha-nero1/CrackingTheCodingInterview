using System.Text;
using System.Collections.Generic;

namespace Core {

  class Utils {
    // Our hash function...
    public static int Hash(string key, int max) {
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

    public static int FindIndexOfKeyInChain(string key, object[,] chain) {
      if (chain != null && chain.Length > 0) {
        for (var i = 0; i < chain.Length; i++) {
          if ((string) chain[i, 0] == key) {
            return i;
          }
        }
      }
      return -1;
    }

    public static ChainNode FindNodeByKey(string key, LinkedList<ChainNode> chain) {
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
  }

  class ChainNode {
    public object[] chain = new object[3];
    public ChainNode next;
    public ChainNode(object[] chain) {
      this.chain = chain;
    }

    public void setNext(ChainNode next) {
      this.next = next;
    }
  }

  class Hashtable {

    private static int INITIAL_ARRAY_SIZE = 1000;

    // We would use dynamic instead of object if we cared about accessing
    // instance methods on the arrays.
    private LinkedList<ChainNode>[] entries = new LinkedList<ChainNode>[Hashtable.INITIAL_ARRAY_SIZE];

    private int collisionCount = 0;

    private int insertionCount = 0;

    public Hashtable(object[,] keyValuePairs) { // Constructor syntax...
      if (keyValuePairs != null && keyValuePairs.Length > 0) {
        for (var i = 0; i < keyValuePairs.GetLength(0); i++) {
          this.set((string) keyValuePairs[i, 0], keyValuePairs[i, 1]);
        }
      }
    }

    public void set(string key, object value) { // ✅
      if (key != null) {
        int hashIndex = Utils.Hash(key, this.entries.Length);
        this.insertionCount += 1;
        var newNode = new ChainNode(new object[] { key, value, this.insertionCount });
        // Set the value in its chain.
        LinkedList<ChainNode> chain = this.entries[hashIndex];
        if (chain != null) {
          // If we find our item in the chain, replace value.
          ChainNode existingNode = Utils.FindNodeByKey(key, chain);
          if (existingNode != null) {
            chain.Remove(existingNode);
          } else if (chain.Count > 0) {
            // Our node might not exist but lets check if collision count needs to increment.
            this.collisionCount += 1;
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
    }

    public object get(string key) { // ✅
      if (key != null) {
        int hashIndex = Utils.Hash(key, this.entries.Length);
        LinkedList<ChainNode> chain = this.entries[hashIndex];
        foreach (ChainNode node in chain) {
          if ((string) node.chain[0] == key) {
            return node.chain[1];
          }
        }
      }
      return null;
    }

    public bool has(string key) { // ✅
      var found = this.get(key);
      return found != null;
    }

    public void remove(string key) { // ✅
      if (key != null && key.Length > 0) {
        int hashIndex = Utils.Hash(key, this.entries.Length);
        LinkedList<ChainNode> chain = this.entries[hashIndex];
        if (chain != null) {
          ChainNode nodeToRemove = Utils.FindNodeByKey(key, chain);
          if (nodeToRemove != null) {
            chain.Remove(nodeToRemove);
          }
        }
      }
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
  }
}