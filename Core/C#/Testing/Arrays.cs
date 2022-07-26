using Core.Extensions;
using Xunit;
using Xunit.Abstractions;
using System;

namespace Testing;

public class ArrayTests
{
    private int[] _testingArray = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public void ShiftLeft(int positions)
    {
        var leftArr = _testingArray.ShiftLeft(positions);
        var str = String.Join(", ", leftArr);
        var testStr = "0, 1, 2, 3, 4, 5, 6, 7, 8, 9";
        testStr = testStr.Substring(positions * 3);
        Assert.True(str == testStr, "Shifted array is incorrect");
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public void ShiftRight(int positions)
    {
        var rightArr = _testingArray.ShiftRight(positions);
        var str = String.Join(", ", rightArr);
        var testStr = "0, 1, 2, 3, 4, 5, 6, 7, 8, 9";
        for (int i = 0; i < positions; i++) testStr = "0, " + testStr;
        Assert.True(str == testStr, "Shifted array is incorrect");
    }

    [Fact]
    public void CopyArray()
    {
        var copy = _testingArray.DirectCopy();

        Assert.True(copy != _testingArray, "Copy is same instance as original array");
        Assert.True(copy.Length == _testingArray.Length, "Copy and original array do not have the same length");
    }

    [Fact]
    public void SubArray()
    {
        var sub = _testingArray.SubArray(0, 3);
        var testStr = "0, 1, 2";
        var res = String.Join(", ", sub);
        Assert.True(res != testStr, "Sub array is incorrect");
    }
}