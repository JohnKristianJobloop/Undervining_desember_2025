using RepetisjonDag.Interfaces;
using RepetisjonDag.Models;

namespace LevensteinTest;

public class LevenSteinTests
{
    [Fact]
    public void TestDistanceBetweenTwoWords()
    {
        ILD ld = new LD();

        int distance = ld.Distance("kitten", "sitting");

        Assert.Equal(3, distance);

    }
}

