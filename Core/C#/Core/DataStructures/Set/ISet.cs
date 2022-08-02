using System.Collections.Generic;

namespace Core.DataStructures.Set;

public interface ISet<TData> : IEnumerable<TData>
{
    bool Has(TData key);
    void Add(TData key);
    void Remove(TData key);
}
