using ExampleTest2.DTOs;
using ExampleTest2.Exceptions;
using ExampleTest2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTest2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IDbService _dbService;

    public PlayersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}/matches")]
    public async Task<IActionResult> GetMatches(int id)
    {
        try
        {
            var matchInfo = await _dbService.GetPlayerMatchesInfo(id);
            return Ok(matchInfo);
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
    }
}