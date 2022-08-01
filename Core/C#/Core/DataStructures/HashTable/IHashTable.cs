using System.Collections.Generic;

namespace Core.DataStructures.HashTable;

/// <summary>
/// Custom C# hashtable implementation.
/// </summary>
/// <typeparam name="TKey">Type of hashtable keys.</typeparam>
/// <typeparam name="TData">Type of hashtable values.</typeparam>
public interface IHashTable<TKey, TData> : IEnumerable<TKey>
{
    TData this[TKey key] { get; set; }
    TData Get(TKey key);
    void Set(TKey key, TData data);
    bool Has(TKey key);
    void Remove(TKey key);
    IEnumerable<TData> Values();
    IEnumerable<TKey> Keys();
    void Clear();
}

public interface IHashTable<T> : IHashTable<string, T>, IEnumerable<string>
{}