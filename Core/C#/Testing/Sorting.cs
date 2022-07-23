using Core.Sorting;
using Xunit;
using Xunit.Abstractions;

namespace Testing;

public class SortingTests
{
    private int[] _testingArr = new int[20]
    {
        1, 19, 20, 7, 8, 5, 2, 12, 13, 4, 3,
        18, 17, 11, 16, 14, 0, 9, 15, 6
    };
    private readonly ITestOutputHelper _output;

    public SortingTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void SelectionSortAsc()
    {
        var res = SelectionSort.Sort(_testingArr);
        for (int i = 1; i < res.Length; i++)
        {
            var prev = res[i - 1];
            var curr = res[i];
            Assert.True(curr >= prev, "Array is out of order");
        }
    }

    [Fact]
    public void SelectionSortDesc()
    {
        var res = SelectionSort.Sort(_testingArr, false);
        _output.WriteLine("Res = {0}", string.Join(", ", res));
        for (int i = 1; i < res.Length; i++)
        {
            var prev = res[i - 1];
            var curr = res[i];
            Assert.True(curr <= prev, "Array is out of order");
        }
    }

    [Fact]
    public void BubbleSortAsc()
    {
        var res = BubbleSort.Sort(_testingArr);
        for (int i = 1; i < res.Length; i++)
        {
            var prev = res[i - 1];
            var curr = res[i];
            Assert.True(curr >= prev, "Array is out of order");
        }
    }

    [Fact]
    public void BubbleSortDesc()
    {
        var res = BubbleSort.Sort(_testingArr, false);

        for (int i = 1; i < res.Length; i++)
        {
            var prev = res[i - 1];
            var curr = res[i];
            Assert.True(curr <= prev, "Array is out of order");
        }
    }

    [Fact]
    public void InsertionSortAsc()
    {
        var res = InsertionSort.Sort(_testingArr);
        for (int i = 1; i < res.Length; i++)
        {
            var prev = res[i - 1];
            var curr = res[i];
            Assert.True(curr <= prev, "Array is out of order");
        }
    }

    [Fact]
    public void InsertionSortDesc()
    {
        var res = InsertionSort.Sort(_testingArr, false);
        for (int i = 1; i < res.Length; i++)
        {
            var prev = res[i - 1];
            var curr = res[i];
            Assert.True(curr >= prev, "Array is out of order");
        }
    }

    [Fact]
    public void MergeSortAsc()
    {
        var res = MergeSort.Sort(_testingArr);
        for (int i = 1; i < res.Length; i++)
        {
            var prev = res[i - 1];
            var curr = res[i];
            Assert.True(curr >= prev, "Array is out of order");
        }
    }

    [Fact]
    public void MergeSortDesc()
    {
        var res = MergeSort.Sort(_testingArr, false);
        for (int i = 1; i < res.Length; i++)
        {
            var prev = res[i - 1];
            var curr = res[i];
            Assert.True(curr <= prev, "Array is out of order");
        }
    }
}