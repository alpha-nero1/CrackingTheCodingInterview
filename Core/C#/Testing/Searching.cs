using Xunit;
using Core.Searching;
using Xunit.Abstractions;

namespace Testing
{
    public class Searching
    {
        private int[] _testingArray = new int[40]
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 19,
            20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
            31, 32, 33, 34, 35, 36, 37, 38, 39
        };
        private readonly ITestOutputHelper _output;

        public Searching(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(3, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        [InlineData(10, 10)]
        [InlineData(11, 11)]
        [InlineData(18, 18)]
        [InlineData(19, 19)]
        [InlineData(39, 39)]
        [InlineData(41, -1)]
        [InlineData(-2, -1)]
        public void LinearSearchLocate(int value, int expectedIndex)
        {
            var res = LinearSearch.Search(_testingArray, value);
            Assert.True(res == expectedIndex, "Incorrect index returned for linear search.");
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(3, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        [InlineData(10, 10)]
        [InlineData(11, 11)]
        [InlineData(18, 18)]
        [InlineData(19, 19)]
        [InlineData(39, 39)]
        [InlineData(41, -1)]
        [InlineData(-2, -1)]
        public void CrossLinearSearchLocate(int value, int expectedIndex)
        {
            var res = CrossLinearSearch.Search(_testingArray, value);
            Assert.True(res == expectedIndex, "Incorrect index returned for cross-linear search.");
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(3, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        [InlineData(10, 10)]
        [InlineData(11, 11)]
        [InlineData(18, 18)]
        [InlineData(19, 19)]
        [InlineData(39, 39)]
        [InlineData(41, -1)]
        [InlineData(-2, -1)]
        public void BinarySearchLocate(int value, int expectedIndex)
        {
            var res = BinarySearch.Search(_testingArray, value);
            Assert.True(res == expectedIndex, "Incorrect index returned for binary search.");
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(3, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        [InlineData(10, 10)]
        [InlineData(11, 11)]
        [InlineData(18, 18)]
        [InlineData(19, 19)]
        [InlineData(39, 39)]
        [InlineData(41, -1)]
        [InlineData(-2, -1)]
        public void TernarySearchLocate(int value, int expectedIndex)
        {
            var res = TernarySearch.Search(_testingArray, value);
            Assert.True(res == expectedIndex, "Incorrect index returned for ternary search.");
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(3, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        [InlineData(10, 10)]
        [InlineData(11, 11)]
        [InlineData(18, 18)]
        [InlineData(19, 19)]
        [InlineData(39, 39)]
        [InlineData(41, -1)]
        [InlineData(-2, -1)]
        public void JumpSearchLocate(int value, int expectedIndex)
        {
            var res = JumpSearch.Search(_testingArray, value);
            Assert.True(res == expectedIndex, "Incorrect index returned for jump search.");
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(3, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        [InlineData(10, 10)]
        [InlineData(11, 11)]
        [InlineData(18, 18)]
        [InlineData(19, 19)]
        [InlineData(39, 39)]
        [InlineData(41, -1)]
        [InlineData(-2, -1)]
        public void InterpolationSearchLocate(int value, int expectedIndex)
        {
            var res = InterpolationSearch.Search(_testingArray, value);
            Assert.True(res == expectedIndex, "Incorrect index returned for interpolation search.");
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(3, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        [InlineData(8, 8)]
        [InlineData(10, 10)]
        [InlineData(11, 11)]
        [InlineData(16, 16)]
        [InlineData(18, 18)]
        [InlineData(19, 19)]
        [InlineData(32, 32)]
        [InlineData(39, 39)]
        [InlineData(41, -1)]
        [InlineData(-2, -1)]
        public void ExponentialSearchLocate(int value, int expectedIndex)
        {
            var res = ExponentialSearch.Search(_testingArray, value);
            _output.WriteLine("Value = {0}, Result = {1}, Expected = {2}", value, res, expectedIndex);
            Assert.True(res == expectedIndex, "Incorrect index returned for exponential search.");
        }
    }
}