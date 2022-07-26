/*
    Trie, used to search man strings at once using an input string.
*/

using System;

namespace Core.Searching;

public class Trie
{
    static readonly int ALPHABET_SIZE = 26;

    public class TrieNode
    {
        public TrieNode[] children = new TrieNode[ALPHABET_SIZE];

        public bool isEndOfWord = false;
    }

    private TrieNode root = new TrieNode();

    public void InsertKeys(string[] keys)
    {
        foreach (var key in keys)
        {
            Insert(key);
        }
    }

    public void Insert(string key)
    {
        int level;
        int length = key.Length;
        int index;

        TrieNode next = root;

        for (level = 0; level < length; level++)
        {
            index = key[level] - 'a';
            if (next.children[index] == null)
            {
                next.children[index] = new TrieNode();
            }
            next = next.children[index];
        }

        next.isEndOfWord = true;
    }

    public bool Search(string key)
    {
        int level;
        int length = key.Length;
        int index;

        TrieNode next = root;

        for (level = 0; level < length; level++)
        {
            index = key[level] - 'a';
            if (next.children[index] == null) return false;
            next = next.children[index];
        }

        return next.isEndOfWord;
    }
}

