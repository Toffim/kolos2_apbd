namespace ExampleTest2.DTOs;

public class NewPlayerDTO
{
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public DateTime BirthDate { get; set; }
    
    public List<MatchRequestDTO> Matches { get; set; }
}

public class MatchRequestDTO
{
    public int MatchId { get; set; }
    public int MVPs { get; set; }
    public double Rating { get; set; }
}