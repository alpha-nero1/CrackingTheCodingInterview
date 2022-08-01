using System;
using Core.DataStructures.HashTable;

namespace Core.DataStructures.Trie;

public class Trie : ITrie
{
    private TrieNode _root { get; set; }
    public static string END_OF_WORD = "_end_";

    public void Add(string word)
    {
        if (String.IsNullOrWhiteSpace(word)) return;
        _root.Add(word);
    }

    public void Remove(string word)
    {
        if (String.IsNullOrWhiteSpace(word)) return;
        _root.Remove(word);
    }

    public bool Search(string word)
    {
        return _root.Search(word);
    }
}

class TrieNode
{
    private IHashTable<TrieNode> _nodes = new HashTable<TrieNode>();

    public void Add(string word)
    {
        if (word.Length == 0)
        {
            // End of word
            _nodes[Trie.END_OF_WORD] = null;
            return;
        }
        var nextChar = $"{word[0]}";
        var nextNode = new TrieNode();

        _nodes.Set(nextChar, nextNode);

        nextNode.Add(word.Substring(1));
    }

    public void Remove(string word)
    {
        if (word.Length == 0)
        {
            // End of word
            _nodes[Trie.END_OF_WORD] = null;
            return;
        }
        var nextChar = $"{word[0]}";
        bool hasNext = _nodes[nextChar] != null;

        if (!hasNext) return;
        _nodes[nextChar].Remove(word.Substring(1));
        _nodes.Set(nextChar, null);
    }

    public bool Search(string word)
    {
        if (word.Length == 0) return true;
        var nextChar = $"{word[0]}";
        bool hasNext = _nodes[nextChar] != null;

        if (hasNext) return _nodes[nextChar].Search(word);
        return false;
    }
}