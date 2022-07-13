using System;
using Core.DataStructures.LinkedList;
using Xunit;
using Xunit.Abstractions;

namespace Core.Testing
{
    public class LinkedListTests
    {
        private readonly ITestOutputHelper _output;
        public LinkedListTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Add_OneItem()
        {
            var ll = new LinkedList<int>();
            ll.Add(1);
            Assert.True(ll[0] == 1, "Linked list incorrect value");
        }

        [Fact]
        public void Add_OneHundredItems()
        {
            var ll = new LinkedList<int>();
            for (int i = 0; i < 100; i++)
            {
                ll.Add(i);
            }
            Assert.True(ll.Count == 100, "Linked list has wrong number of insertions");
        }

        [Fact]
        public void AddAndRemove_OneHundredItems()
        {
            var ll = new LinkedList<int>();
            for (int i = 0; i < 100; i++)
            {
                bool even = i % 2 == 0;
                if (even) ll.Add(i);
                else ll.Remove(i - 1);
            }
            Assert.True(ll.Count == 0, "Linked list has wrong number of insertions");
        }

        [Fact]
        public void Iterate_Ten()
        {
            IterationTest(10);
        }

        [Fact]
        public void Iterate_OneThousand()
        {
            IterationTest(1000);
        }

        [Fact]
        public void Iterate_TenThousand()
        {
            IterationTest(10000);
        }

        private void IterationTest(int iterations)
        {
            var ll = new LinkedList<int>();
            for (int i = 0; i < iterations; i++)
            {
                ll.Add(i);
            }

            int itCount = 0;

            foreach (int i in ll)
            {
                itCount += 1;
            }
            Assert.True(itCount == ll.Count, "Linked list did not iterate correctly.");
        }
    }
}