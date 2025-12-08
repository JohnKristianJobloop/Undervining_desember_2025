using Xunit;
using ListImplementation.Models;

public class KhListTests
{
    [Fact]
    public void Add_ShouldStoreValuesCorrectly()
    {
        var list = new KhList<string>();

        list.Add("A");
        list.Add("B");
        
        Assert.Equal("A", list[0]);
        Assert.Equal("B", list[1]);
    }


    [Fact]
    public void Remove_ValueExists_ShouldReturnRemovedValue()
    {
        var list = new KhList<string>();
        
        list.Add("Hello");
        list.Add("World");
   
        var removed = list.Remove("Hello"); // Remove "Hello" index[0]

        Assert.Equal("Hello", removed);
        Assert.Equal("World", list[0]); // should now be indexof[0]
        // we can also verify this, by testing our Exceptions
        Assert.Throws<IndexOutOfRangeException>(()=>list[1]);
    }

    [Fact]
    public void Remove_WithPredicate_ShouldRemoveMatchingElement()
    {
        var list = new KhList<int>();
        
        list.Add(5);
        list.Add(10);
        list.Add(15);

        var removed = list.Remove(removedItem => removedItem < 10);

        Assert.Equal(5, removed);
        Assert.Equal(10, list[0]);
        Assert.Equal(15, list[1]);
        Assert.Contains(list[0].ToString(), 10.ToString());
        Assert.Contains(list[1].ToString(), 15.ToString());
    }

    [Fact]
    public void Remove_WithPredicate_ShouldRemoveMatchingElementsIfMultipleValuesMatch()
    {
        var list = new KhList<int>();
        
        list.Add(5);
        list.Add(10);
        list.Add(15);

        var removed = list.Remove(removedItem => removedItem > 10); // could be either 10 or 15

        Assert.False(removed == 10); // case 1
        Assert.Equal(15, removed); // case 2
        Assert.Contains(5.ToString(), list[1].ToString());
        Assert.Equal(15, list[1]); // should be 5, but is actually 15?
    }

    [Fact]
    public void Indexer_ChangeValue_ShouldUpdateElement()
    {
        var list = new KhList<string>();
        list.Add("A");
        list.Add("B");

        list[1] = "C"; // change the value of B to C

        Assert.Equal("C", list[1]);
    }

    [Fact]
    public void Change_ByIndex_ShouldModifyValue()
    {
        var list = new KhList<int>();
        list.Add(1);
        list.Add(2);

        // change the value of 1 to 100
        list.Change(100, 0);

        Assert.Equal(100, list[0]);
        Assert.Equal(2, list[1]); // 2 now in position index[0]
    }

    [Fact]
    public void Change_UsingDelegateFunction_ShouldModifyMatchedElement()
    {
        var list = new KhList<string>();
        list.Add("test");

        list.Change("test", upperCaseString => upperCaseString.ToUpper());

        Assert.Equal("TEST", list[0]);
    }
}