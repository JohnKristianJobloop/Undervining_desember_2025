using System.Reflection;
using ExampleWebApi.DataContext;
using ExampleWebApi.Interfaces;
using ExampleWebApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((hostBuilder, configBuilder) =>
{
    configBuilder.AddUserSecrets(Assembly.GetExecutingAssembly()).AddEnvironmentVariables();
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    opt =>
    {
        var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
    }
);
builder.Services.AddControllers()
.ConfigureApiBehaviorOptions(opt => {opt.SuppressModelStateInvalidFilter = true;});

var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Missing Connection string 'Default'");

builder.Services.AddDbContext<IDiaryService, DiaryDbContext>(opt => {opt.UseSqlite(connectionString);});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();
