using ExampleWebApi.Interfaces;
using ExampleWebApi.Services;

namespace ExampleWebApi.Models.DTO;

public record DiaryEntryDTO(string Title, string Description)
{
    public DiaryEntry CreateEntry(IDiaryService service)
    {
        var entry = new DiaryEntry
        {
            Title = Title,
            Description = Description,
            Published = DateTime.UtcNow
        };
        service.Add(entry);
        return entry;
    }

    public async Task<DiaryEntry> CreateEntryAsync(IDiaryService service)
    {
        var entry = new DiaryEntry
        {
            Title = Title,
            Description = Description,
            Published = DateTime.UtcNow
        };
        await service.AddAsync(entry);
        return entry;
    }
}
