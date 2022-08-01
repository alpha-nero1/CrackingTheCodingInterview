using System.Collections;
using System.Collections.Generic;
using Core.DataStructures.HashTable;

namespace Core.DataStructures.Set;

public class Set : ISet
{
    public IHashTable<bool?> _map { get; set; }

    public bool Has(string key)
    {
        return _map[key] == true;
    }

    public void Add(string key)
    {
        _map[key] = true;
    }

    public void Remove(string key)
    {
        _map[key] = null;
    }

    public IEnumerator<string> GetEnumerator()
    {
        return _map.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _map.GetEnumerator();
    }
}
