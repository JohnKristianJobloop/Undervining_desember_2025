using System.Diagnostics;
using ExampleWebApi.Interfaces;
using ExampleWebApi.Models;
using ExampleWebApi.Models.DTO;
using ExampleWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace ExampleWebApi.Controllers;
 
[Route("api/[controller]")] //Dette representerer rawURl til controlleren vår. noe a.la http://localhost:5093/api/diaryentries
[ApiController]
public class DiaryEntriesController(IDiaryService service, ILogger<DiaryEntriesController> logger) : ControllerBase
{
    /// <summary>
    /// Gets all entries served by the Diary Service
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get() => Ok(await service.GetAsync()); //GET mot http://localhost:5093/api/diaryentries


    /// <summary>
    /// Greates a new entry based on a Title and a Description. Default Date is the date the entry is published to the Diary Service.
    /// </summary>
    /// <param name="dto">A Data Transfer Object containing the Title and Description of the new entry. </param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] DiaryEntryDTO dto)
    {
        var stopWatch = Stopwatch.StartNew();
        if(!ModelState.IsValid) return BadRequest("Invalid format of incomming data");
        var result = await dto.CreateEntryAsync(service);
        stopWatch.Stop();
        logger.LogInformation($"The operation took: {stopWatch.ElapsedMilliseconds}");
        return Ok(result);
    }

    /// <summary>
    /// Gets a spesified entry, based on a Guid.
    /// </summary>
    /// <param name="id">the Id of the entry</param>
    /// <returns></returns>
    [HttpGet("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id)
    {
        var entries = await service.GetAsync();
        return entries.FirstOrDefault(entry => entry.Id == id) is DiaryEntry entry ? Ok(entry) : NotFound();
    }
}
