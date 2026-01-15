using System;
using ExampleWebApi.Interfaces;
using ExampleWebApi.Models;
using ListImplementation.Models;

namespace ExampleWebApi.Services;

public class DiaryService: IDiaryService
{
    private List<DiaryEntry> _entries = [];

    public int Count => _entries.Count;
    public async Task<int>CountAsync() => await Task.Run(()=>_entries.Count);

    public void Add(DiaryEntry entry) => _entries.Add(entry);

    public async Task AddAsync(DiaryEntry entry) => await Task.Run(()=>_entries.Add(entry));

    public IEnumerable<DiaryEntry> Get() => _entries;

    public async Task<IEnumerable<DiaryEntry>> GetAsync() => await Task.Run(()=>_entries.ToList());

}
