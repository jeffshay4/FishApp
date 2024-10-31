using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FishAppAPI.Data;

public partial class ExtFishingLocation
{
    //CHat GPT: This is the table i imported into Visual Studio. When I run my "get" API, I get an error message that says a primary key is not defined. How can I fix that
    [Key] // This attribute specifies that LocationId is the primary key
    public int LocationId { get; set; }

    public string Name { get; set; } = null!;

    public string State { get; set; } = null!;

    public bool? Boat { get; set; }

    public decimal? Depth { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}