using System.Transactions;
using ExampleTest2.DTOs;
using ExampleTest2.Exceptions;
using ExampleTest2.Models;
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
    
    [HttpPost]
    public async Task<IActionResult> AddPlayerWithMatches(NewPlayerDTO newData)
    {
        var player = new Player()
        {
            FirstName = newData.FirstName,
            LastName = newData.LastName,
            BirthDate = newData.BirthDate,
        };

        var playerMatches = new List<PlayerMatch>();
        foreach (var playerMatch in newData.Matches)
        {
            var matchExists = await _dbService.DoesMatchExist(playerMatch.MatchId);
            if(!matchExists)
                return NotFound($"Match with ID - {playerMatch.MatchId} doesn't exist");
    
            playerMatches.Add(new PlayerMatch()
            {
                MatchId = playerMatch.MatchId,
                PlayerId = player.PlayerId,
                MVPs = playerMatch.MVPs,
                Rating = playerMatch.Rating
            });
        }
    
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _dbService.AddNewPlayer(player);
            await _dbService.AddNewPlayerMatches(playerMatches);
    
            scope.Complete();
        }
    
        return Ok("Success updating " + newData.FirstName + " " + newData.LastName);
    }
}