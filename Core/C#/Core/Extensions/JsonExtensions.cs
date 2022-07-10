using System.Collections.Generic;
using System.Text.Json;

namespace Core.Extensions
{
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