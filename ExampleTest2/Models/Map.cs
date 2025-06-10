using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleTest2.Models;

[Table("Map")]
public class Map
{
    [Key]
    public int MapId { get; set; }
    [MaxLength(100)]
    public String Name { get; set; } = null!;
    [MaxLength(100)]
    public String Type { get; set; } = null!;
    
    public ICollection<Match> Matches { get; set; } = null!;
}