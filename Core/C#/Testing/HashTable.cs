using System;
using Xunit;
using Core.DataStructures;

namespace Core.Testing
{
    public class HashTable
    {
        [Fact]
        public void Set_OneItem()
        {
            var ht = new HashTable<int>();
            ht.Set("hello", 1);
            Assert.True(ht.Get("hello") == 1, "Key for hello of value 1 was not set");
        }
    }
}
