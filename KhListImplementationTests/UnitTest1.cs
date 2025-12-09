namespace KhListImplementationTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // add
        var a = 10 + 10;

        // act
        var res = 20;
        
        // assert   
        Assert.Equal(res, a);
    }
}
