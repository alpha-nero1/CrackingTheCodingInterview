using Core.DataStructures.Set;
using Xunit;
using Xunit.Abstractions;

namespace Testing;

public class Set
{
    private readonly ITestOutputHelper _output;
    public Set(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void CountValues()
    {
        var st = new Set<string>();

        st.Add("hello");
        st.Add("hey");
        st.Add("hexo");
        st.Add("hipopotomous");

        Assert.True(st.Count() == 4, "Set does not contain all values");
    }

    [Fact]
    public void RemovesDuplicates()
    {
        var st = new Set<string>();

        st.Add("hello");
        st.Add("hello");
        st.Add("hexo");
        st.Add("hexo");

        Assert.True(st.Count() == 2, "Set contains duplicates");
    }

    [Fact]
    public void RemoveWorks()
    {
        var st = new Set<string>();

        st.Add("hello");
        st.Add("alphabet");
        st.Add("soup");
        st.Add("group");

        st.Remove("group");

        Assert.True(st.Count() == 3, "Set did not remove properly");
        Assert.False(st.Has("group"), "Set still contains word");
    }

    [Fact]
    public void RemoveWorksInteger()
    {
        var st = new Set<int>();

        st.Add(1);
        st.Add(2);
        st.Add(3);
        st.Add(4);

        st.Remove(2);

        Assert.True(st.Count() == 3, "Set did not remove properly");
        Assert.False(st.Has(2), "Set still contains int");
    }
}