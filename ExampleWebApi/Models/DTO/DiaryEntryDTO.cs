using ExampleWebApi.Services;

namespace ExampleWebApi.Models.DTO;

public record DiaryEntryDTO(string Title, string Description)
{
    public DiaryEntry CreateEntry(DiaryService service)
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
}
