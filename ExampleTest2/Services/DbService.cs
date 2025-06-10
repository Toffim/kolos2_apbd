using System.Data;
using ExampleTest2.Data;
using ExampleTest2.DTOs;
using ExampleTest2.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<PlayerMatchInfoDTO> GetPlayerMatchesInfo(int playerId)
    {
        var playerMatchInfo = await _context.Players
            .Select(e => new PlayerMatchInfoDTO
            {
                PlayerId = e.PlayerId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                BirthDate = e.BirthDate,
                Matches = e.PlayerMatches.Select(e => new MatchDTO()
                {
                    Tournament = e.Match.Tournament.Name,
                    Map = e.Match.Map.Name,
                    MVPs = e.MVPs,
                    MatchDate = e.Match.MatchDate,
                    Team1Score = e.Match.Team1Score,
                    Team2Score = e.Match.Team2Score,
                    Rating = e.Rating,
                }).ToList()
            })
            .FirstOrDefaultAsync(e => e.PlayerId == playerId);

        if (playerMatchInfo is null)
            throw new NotFoundException();
        
        return playerMatchInfo;
    }
}