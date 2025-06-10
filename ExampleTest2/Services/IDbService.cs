using ExampleTest2.DTOs;
using ExampleTest2.Models;

namespace ExampleTest2.Services;

public interface IDbService
{
    Task<PlayerMatchInfoDTO> GetPlayerMatchesInfo(int playerId);
    
    Task<bool> DoesMatchExist(int matchId);
    Task AddNewPlayer(Player order);
    Task AddNewPlayerMatches(IEnumerable<PlayerMatch> playerMatches);
}