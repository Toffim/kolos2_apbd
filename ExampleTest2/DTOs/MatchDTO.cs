namespace ExampleTest2.DTOs;

public class MatchDTO
{
    public String Tournament { get; set; }
    public String Map { get; set; }
    public int MVPs { get; set; }
    
    public DateTime MatchDate { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
    public double? Rating { get; set; }
}