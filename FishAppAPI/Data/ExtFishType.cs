using System;
using System.Collections.Generic;

namespace FishingWebAppAPI.Data;

public partial class ExtFishType
{
    public int FishId { get; set; }

    public string Name { get; set; } = null!;

    public int LocationId { get; set; }

    public virtual ExtFishingLocation Location { get; set; } = null!;
}
