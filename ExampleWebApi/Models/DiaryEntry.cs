using System;

namespace ExampleWebApi.Models;

public class DiaryEntry : IComparable<DiaryEntry>
{
    public Guid Id {get;init;} = Guid.NewGuid();
    public string Title {get;set;}
    public DateTime Published {get;init;}
    public string Description {get;set;}
    public int CompareTo(object? obj)
    {
        if (obj is not DiaryEntry entry) throw new ArgumentException(nameof(obj));
        return (int)(Published - entry.Published).TotalDays;
    }

    public int CompareTo(DiaryEntry? other)
    {
        return (int)(Published - other.Published).TotalDays;
    }
}
