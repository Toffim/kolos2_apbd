using ExampleTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Map> Maps { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<PlayerMatch> PlayerMatches { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>().HasData(new List<Player>()
        {
            new Player() { PlayerId = 1, FirstName = "Juziek", LastName = "Kowalski", BirthDate = DateTime.Parse("1950-05-02") },
            new Player() { PlayerId = 2, FirstName = "Joanna", LastName = "Bosna", BirthDate = DateTime.Parse("1950-05-02") },
            new Player() { PlayerId = 3, FirstName = "Krzysiek", LastName = "Wiosna", BirthDate = DateTime.Parse("1950-05-02") },
        });

        modelBuilder.Entity<Match>().HasData(new List<Match>()
        {
            new Match() { MatchId = 1, TournamentId = 1, MapId = 1, MatchDate = DateTime.Parse("1950-05-02"), Team1Score = 20, Team2Score = 10, BestRating = 20.52},
        });
        
        modelBuilder.Entity<Map>().HasData(new List<Map>()
        {
            new Map() { MapId = 1, Name = "Chinatown", Type = "Large" },
        });
        
        modelBuilder.Entity<Tournament>().HasData(new List<Tournament>()
        {
            new Tournament() { TournamentId = 1, Name = "World Championship", StartDate = DateTime.Parse("1970-05-02"), EndDate = DateTime.Parse("1970-05-04")}
        });
        
        modelBuilder.Entity<PlayerMatch>().HasData(new List<PlayerMatch>()
        {
            new PlayerMatch() { MatchId = 1, PlayerId = 1, MVPs = 1, Rating = 15.1 },
        });
    }
}