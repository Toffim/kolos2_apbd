using ExampleTest2.Models;

namespace ExampleTest2.DTOs;

public class PlayerMatchInfoDTO
{
    public int PlayerId { get; set; }
    public String FirstName { get; set; } = null!;
    public String LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }

    public List<MatchDTO> Matches { get; set; } = null!;
}