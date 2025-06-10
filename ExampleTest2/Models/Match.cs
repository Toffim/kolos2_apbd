using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Models;

[Table("Match")]
public class Match
{
    [Key]
    public int MatchId { get; set; }
    [ForeignKey("TournamentId")]
    public int TournamentId { get; set; }
    [ForeignKey("MapId")]
    public int MapId { get; set; }
    
    public DateTime MatchDate { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
    [Column(TypeName = "numeric")]
    [Precision(4, 2)]
    public double? BestRating { get; set; }
    
    public ICollection<PlayerMatch> PlayerMatches { get; set; } = null!;
    
    public Map Map { get; set; } = null!;
    public Tournament Tournament { get; set; } = null!;
}