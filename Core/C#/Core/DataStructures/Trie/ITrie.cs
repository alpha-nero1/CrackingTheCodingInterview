namespace Core.DataStructures.Trie;

public interface ITrie
{
    void Add(string word);
    bool Has(string word);

    /// <summary>
    /// See what words this prefix matches in the Trie.
    /// </summary>
    string[] Search(string word);
}