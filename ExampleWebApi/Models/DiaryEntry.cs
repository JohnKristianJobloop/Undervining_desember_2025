using System;
using System.ComponentModel.DataAnnotations;

namespace ExampleWebApi.Models;

public class DiaryEntry
{
    [Key]
    public Guid Id {get;init;} = Guid.NewGuid();
    public string Title {get;set;}
    public DateTime Published {get;init;}
    public string Description {get;set;}
}
