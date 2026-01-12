using ExampleWebApi.Models;
using ExampleWebApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DiaryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//Når vi lager endepunkter, kan det være greit å ha følgende i bakhode:
//La gjerne kombinasjonen HttpMetode og route være en slagt Subject Verb sammensettning.
//Hvor kombinasjonen av disse forteller oss hva forespørselen handler om. 
app.MapGet("/diaryentries", (DiaryService service)=> service.Get());

app.MapPost("/diaryentries", (string title, string description, DiaryService service) =>
{
    var entry = new DiaryEntry
    {
        Title = title,
        Description = description,
        Published = DateTime.UtcNow
    };
    service.Add(entry);
    return Results.Created($"/diaryentries/{entry.Id}", entry);
});


app.MapGet("/diaryentries/{id:Guid}", (Guid id, DiaryService service)=> service.Get().FirstOrDefault(entry => entry.Id == id) is DiaryEntry entry ? Results.Ok(entry) : Results.NotFound());


app.Run();
