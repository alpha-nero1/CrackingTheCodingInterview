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

    // Json extensions for ease of use for System.Text.Json.
    public static class JsonExtensions
    {
        public static T ToObject<T>(this string json)
        {
            var deserialised = JsonSerializer.Deserialize<T>(json);
            return deserialised;
        }

        public static string ToString<T>(this T obj)
        {
            var serialised = JsonSerializer.Serialize<T>(obj);
            return serialised;
        }
    }
}