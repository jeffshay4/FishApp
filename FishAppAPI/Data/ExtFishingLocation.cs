using System;
using System.Collections.Generic;

namespace FishingWebAppAPI.Data;

public partial class ExtFishingLocation
{
    public int LocationId { get; set; }

    public string Name { get; set; } = null!;

    public string State { get; set; } = null!;

    public bool? Boat { get; set; }

    public decimal? Depth { get; set; }

    public virtual ICollection<ExtFishType> ExtFishTypes { get; set; } = new List<ExtFishType>();
}
