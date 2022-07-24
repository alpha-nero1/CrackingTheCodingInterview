// See https://aka.ms/new-console-template for more information


public class Trie
{


}

public class TrieNode
{
    private Dictionary<char, TrieNode> _children = new Dictionary<char, TrieNode>();
    private List<int> _indexes = new List<int>();
    private char _char;

    public TrieNode() {}

    public TrieNode(char character)
    {
        _char = character;
    }

    public void InsertString(string remainingString, int index)
    {
        _indexes.Add(index);
        if (String.IsNullOrWhiteSpace(remainingString))
        {
            _children['\0'] = new TrieNode();
        };

        // Get the next char for what is remaining.
        var nextChar = remainingString[0];
        var nextChild = new TrieNode();

        if (_children.ContainsKey(nextChar))
        {
            // If we already have the next char then
            nextChild = _children[nextChar];
        }

        var remaining = remainingString.Substring(1);
        nextChild.InsertString(remainingString, index + 1);
    }

    public List<int> Search(string s)
    {
        if (String.IsNullOrWhiteSpace(s)) return _indexes;

        char first = s[0];

        if (_children.ContainsKey(first))
        {
            string remainder = s.Substring(1);
            return _children[first].Search(remainder);
        }

        return null;
    }

    public bool Terminates()
    {
        return _children.ContainsKey('\0');
    }

    public TrieNode GetChild(char c)
    {
        return _children.GetValueOrDefault(c);
    }
}