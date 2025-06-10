using ExampleTest2.DTOs;

namespace ExampleTest2.Services;

public interface IDbService
{
    Task<PlayerMatchInfoDTO> GetPlayerMatchesInfo(int playerId);
}