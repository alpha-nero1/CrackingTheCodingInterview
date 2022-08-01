namespace Core.DataStructures.Trie;

public interface ITrie
{
    void Add(string word);
    bool Search(string word);
}