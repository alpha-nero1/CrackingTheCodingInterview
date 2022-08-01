using System.Collections.Generic;

namespace Core.DataStructures
{
    /// <summary>
    /// Custom C# hashtable implementation.
    /// </summary>
    /// <typeparam name="T">Type of hashtable values.</typeparam>
    public interface IHashTable<T> : IEnumerable<string>
    {
        T this[string key] { get; set; }

        /// <summary>
        /// Get a value from the hashtable using a key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Value if present, default if not.</returns>
        T Get(string key);

        /// <summary>
        /// Get all values in dict.
        /// </summary>
        /// <returns>Enumerable of values.</returns>
        IEnumerable<T> Values();

        /// <summary>
        /// Get all keys used in the dictionary.
        /// </summary>
        /// <returns>Enumerable of keys.</returns>
        IEnumerable<string> Keys();

        /// <summary>
        /// Set a value in the hashtable.
        /// </summary>
        /// <param name="key">Key to store valie against.</param>
        /// <param name="value">Value to store against key.</param>
        void Set(string key, T value);

        /// <summary>
        /// Check if a key has a value in the dictionary.
        /// </summary>
        /// <param name="key">Key to check.</param>
        /// <returns></returns>
        bool Has(string key);

        /// <summary>
        /// Remove an item from the hastable.
        /// </summary>
        /// <param name="key">Key to remove.</param>
        void Remove(string key);

        /// <summary>
        /// Clear the hashtable.
        /// </summary>
        void Clear();
    }
}