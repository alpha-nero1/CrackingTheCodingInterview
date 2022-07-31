using System.Collections.Generic;
using Core.DataStructures.Graph;
using Core.Searching;
using Xunit;
using Xunit.Abstractions;

namespace Testing;

public class GraphNodeTests
{
    private GraphNode<int> _testGraph = new GraphNode<int>(
        1,
        new List<GraphNode<int>>
        {
            new(
                2,
                new List<GraphNode<int>>
                {
                    new(3),
                    new(4),
                    new(5),
                    new(6),
                    new(7),
                }
            ),
            new(
                3,
                new List<GraphNode<int>>
                {
                    new(8),
                    new(9),
                    new(
                        10,
                        new List<GraphNode<int>>
                        {
                            new(21),
                            new(22),
                            new(23),
                            new(24),
                            new(25),
                        }
                    ),
                    new(11),
                    new(12),
                }
            ),
            new(
                5,
                new List<GraphNode<int>>
                {
                    new(13),
                    new(14),
                    new(15),
                    new(16),
                    new(17),
                }
            )
        }
    );
    private ITestOutputHelper _output { get; }

    public GraphNodeTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void DfsIterate()
    {
        _testGraph.Reset();
        int graphCount = 24;
        int count = 0;
        _testGraph.DepthFirstSearch((GraphNode<int> node) => {
            count += 1;
            return false;
        });
        Assert.True(graphCount == count, "Did not count correct amount in graph");
    }

    [Theory]
    [InlineData(11)]
    [InlineData(22)]
    [InlineData(25)]
    [InlineData(17)]
    [InlineData(1)]
    [InlineData(3)]
    public void DfsFind(int value)
    {
        _testGraph.Reset();
        bool found = _testGraph.DepthFirstSearch((GraphNode<int> node) => node.Value == value);
        Assert.True(found, "Could not find value in graph.");
    }

    [Theory]
    [InlineData(101)]
    [InlineData(220)]
    [InlineData(250)]
    [InlineData(170)]
    [InlineData(-2)]
    [InlineData(0)]
    public void DfsNonExistant(int value)
    {
        _testGraph.Reset();
        bool found = _testGraph.DepthFirstSearch((GraphNode<int> node) => node.Value == value);
        Assert.False(found, "Returned true for non existant value");
    }

    [Fact]
    public void DfsInOrder()
    {
        int[] expectedOrder = new int[24]
        {
            1, 2, 3, 4, 5, 6, 7,
            3, 8, 9, 10, 21, 22, 23,
            24, 25, 11, 12, 5, 13, 14,
            15, 16, 17
        };
        _testGraph.Reset();
        int index = 0;
        _testGraph.DepthFirstSearch((GraphNode<int> node) =>
        {
            Assert.True(node.Value == expectedOrder[index], "Depth first search occured out of order");
            index += 1;
            return false;
        });
    }

    [Fact]
    public void BfsIterate()
    {
        _testGraph.Reset();
        int graphCount = 24;
        int count = 0;
        _testGraph.BreadthFirstSearch((GraphNode<int> node) => {
            count += 1;
            return false;
        });
        Assert.True(graphCount == count, "Did not count correct amount in graph");
    }

    [Theory]
    [InlineData(11)]
    [InlineData(22)]
    [InlineData(25)]
    [InlineData(17)]
    [InlineData(1)]
    [InlineData(3)]
    public void BfsFind(int value)
    {
        _testGraph.Reset();
        bool found = _testGraph.BreadthFirstSearch((GraphNode<int> node) => node.Value == value);
        Assert.True(found, "Could not find value in graph.");
    }

    [Theory]
    [InlineData(101)]
    [InlineData(220)]
    [InlineData(250)]
    [InlineData(170)]
    [InlineData(-2)]
    [InlineData(0)]
    public void BfsNonExistant(int value)
    {
        _testGraph.Reset();
        bool found = _testGraph.BreadthFirstSearch((GraphNode<int> node) => node.Value == value);
        Assert.False(found, "Returned true for non existant value");
    }

    [Fact]
    public void BfsInOrder()
    {
        int[] expectedOrder = new int[24]
        {
            1, 2, 3, 5, 3, 4, 5, 6, 7,
            8, 9, 10, 11, 12, 13, 14, 15, 16,
            17, 21, 22, 23, 24, 25
        };
        _testGraph.Reset();
        int index = 0;
        _testGraph.BreadthFirstSearch((GraphNode<int> node) =>
        {
            Assert.True(node.Value == expectedOrder[index], "Breadth first search occured out of order");
            index += 1;
            return false;
        });
    }
}