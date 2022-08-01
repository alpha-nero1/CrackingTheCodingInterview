using System.Collections.Generic;

namespace Core.DataStructures.Set;

public interface ISet : IEnumerable<string>
{
    bool Has(string key);
    void Add(string key);
    void Remove(string key);
}
