using System;
using Xunit;
using Xunit.Abstractions;
using Core.DataStructures.HashTable;
using System.Linq;

namespace Core.Testing;

public class HashTableTests
{
    private readonly ITestOutputHelper _output;
    public HashTableTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void Set_OneItem()
    {
        var ht = new HashTable<int>();
        ht.Set("hello", 1);
        Assert.True(ht.Get("hello") == 1, "Key for hello of value 1 was not set.");
    }

    [Fact]
    public void Set_OneHundredItems()
    {
        var ht = new HashTable<int>();

        for (int i = 0; i < 100; i++)
        {
            ht[$"Hello-{i}"] = i;
        }

        for (int i = 0; i < 100; i++)
        {
            var val = ht[$"Hello-{i}"];
            Assert.True(ht[$"Hello-{i}"] == i, $"Key for \"Hello-{i}\" has incorrect value.");
        }
    }

    [Fact]
    public void Set_OneThousandItems()
    {
        var ht = new HashTable<int>();

        for (int i = 0; i < 1000; i++)
        {
            ht[$"Hello-{i}"] = i;
        }

        for (int i = 0; i < 1000; i++)
        {
            var val = ht[$"Hello-{i}"];
            Assert.True(ht[$"Hello-{i}"] == i, $"Key for \"Hello-{i}\" has incorrect value.");
        }
    }

    [Fact]
    public void Clear_OneThousandItems()
    {
        var ht = new HashTable<int>();

        for (int i = 0; i < 1000; i++)
        {
            ht[$"Hello-{i}"] = i;
        }

        ht.Clear();

        Assert.True(ht.Keys().Count() < 1, "HashTable not cleared.");
    }

    [Fact]
    public void Remove_FiveHundredItems()
    {
        var ht = new HashTable<int>();

        for (int i = 0; i < 1000; i++)
        {
            ht[$"Hello-{i}"] = i;
        }

        for (int i = 0; i < 500; i++)
        {
            ht.Remove($"Hello-{i}");
        }

        Assert.True(ht.Keys().Count() == 500, "HashTable did not remove items properly.");
    }
}
