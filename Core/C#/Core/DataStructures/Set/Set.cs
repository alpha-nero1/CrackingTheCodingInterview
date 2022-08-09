using System.Collections;
using System.Collections.Generic;
using Core.DataStructures.HashTable;

namespace Core.DataStructures.Set;

public class Set<TData> : ISet<TData>
{
    public IHashTable<TData, bool?> _map { get; set; } = new HashTable<TData, bool?>();

    public bool Has(TData key)
    {
        return _map[key] == true;
    }

    public void Add(TData key)
    {
        _map[key] = true;
    }

    public void Remove(TData key)
    {
        _map[key] = null;
    }

    public int Count()
    {
        int count = 0;
        var values = _map.Values();
        foreach (var val in values)
        {
            count += 1;
        }
        return count;
    }

    public IEnumerator<TData> GetEnumerator()
    {
        return _map.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _map.GetEnumerator();
    }
}
