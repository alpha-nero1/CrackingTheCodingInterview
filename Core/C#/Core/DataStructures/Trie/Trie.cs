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

    public bool Has(string word)
    {
        return _root.Has(word);
    }

    public string[] Search(string word)
    {
        return _root.Search(word);
    }
}

class TrieNode
{
    private IHashTable<string, TrieNode> _nodes = new HashTable<string, TrieNode>();

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

    public bool Has(string word)
    {
        if (word.Length == 0) return true;
        var nextChar = $"{word[0]}";
        bool hasNext = _nodes[nextChar] != null;

        if (hasNext) return _nodes[nextChar].Has(word);
        return false;
    }

    private TrieNode LastTrieNodeOfWord(string word)
    {
        var nextChar = $"{word[0]}";
        TrieNode next = _nodes[nextChar];

        while (next != null)
        {
            word = word.Substring(1);
            nextChar = $"{word[0]}";
            next = _nodes[nextChar];
        }
        return next;
    }

    // Clues = https://www.geeksforgeeks.org/auto-complete-feature-using-trie/
    public string[] Search(string word)
    {
        var words = new string[] {};
        // If word is not found in Trie then return empty.
        if (!Has(word)) return words;

        var lastNode = LastTrieNodeOfWord(word);

        var lastNodeChars = lastNode._nodes.Keys();

        foreach (var nextChar in lastNodeChars)
        {

        }

        return words;
    }
}