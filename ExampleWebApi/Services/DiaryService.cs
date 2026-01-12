using System;
using ExampleWebApi.Models;
using ListImplementation.Models;

namespace ExampleWebApi.Services;

public class DiaryService
{
    private KhList<DiaryEntry> _entries = new();

    public int Count => _entries.Count;

    public void Add(DiaryEntry entry) => _entries.Add(entry);

    public IEnumerable<DiaryEntry> Get() => _entries.Values;

}
