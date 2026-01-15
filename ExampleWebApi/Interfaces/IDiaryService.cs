using System;
using ExampleWebApi.Models;

namespace ExampleWebApi.Interfaces;

public interface IDiaryService
{
    int Count{get;}
    Task<int> CountAsync();
    void Add(DiaryEntry entry);
    Task AddAsync(DiaryEntry entry);
    IEnumerable<DiaryEntry> Get();
    Task<IEnumerable<DiaryEntry>> GetAsync();
}
