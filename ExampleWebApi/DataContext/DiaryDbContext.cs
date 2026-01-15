using System;
using System.ComponentModel.DataAnnotations;
using ExampleWebApi.Interfaces;
using ExampleWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebApi.DataContext;

public class DiaryDbContext(DbContextOptions<DiaryDbContext> opt) : DbContext(opt), IDiaryService
{
    public DbSet<DiaryEntry> DiaryEntries {get;init;}

    public int Count => DiaryEntries.Count();

    public async Task<int> CountAsync() => await DiaryEntries.CountAsync();

    public void Add(DiaryEntry entry) {
        DiaryEntries.Add(entry);
        SaveChanges();
    }

    public async Task AddAsync(DiaryEntry entry)
    {
        await DiaryEntries.AddAsync(entry);
        await SaveChangesAsync();
    }
    public IEnumerable<DiaryEntry> Get() => DiaryEntries;

    public async Task<IEnumerable<DiaryEntry>> GetAsync() => await DiaryEntries.ToListAsync();
}
