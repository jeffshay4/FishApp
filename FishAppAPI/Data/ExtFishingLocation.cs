using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishAppAPI.Data;

public partial class ExtFishingLocation
{
    [Key] // This indicates that LocationId is the primary key
    public int LocationId { get; set; }

    [Required] // This makes sure Name is not null
    public string Name { get; set; } = null!;

    [Required] // This makes sure State is not null
    public string State { get; set; } = null!;

    public bool? Boat { get; set; }

    public decimal? Depth { get; set; }

    // Navigation property for related fish types
    public virtual ICollection<ExtFishType> ExtFishTypes { get; set; } = new List<ExtFishType>();
}

