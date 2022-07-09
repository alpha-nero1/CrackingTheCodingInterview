using System.Collections.Generic;
using System.Text.Json;

namespace Core.Extensions
{
    public static class DictionaryExtensions
    {
        // Simple dictionary extension to add props of dictionary 2 to dictionary 1.
        public static void Merge<T>(this IDictionary<string, T> dict, IDictionary<string, T> otherDict)
        {
            foreach (var keyValuePair in otherDict)
            {
                dict[keyValuePair.Key] = keyValuePair.Value;
            }
        }
    }
}