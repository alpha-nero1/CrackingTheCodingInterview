using System.Collections.Generic;

namespace Core.Extensions
{
    public class DictionaryExtensions
    {
        // Simple dictionary extension to add props of dictionary 2 to dictionary 1.
        public static void Merge<T>(this IDictionary<string, T> dict, IDictionary<string, T> otherDict)
        {
            foreach (var keyValuePair in otherDict)
            {
                dict.Add(keyValuePair.Keym keyValuePair.Value);
            }
        }
    }
}