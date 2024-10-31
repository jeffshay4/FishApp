using System;
using System.Collections.Generic;

namespace FishingWebAppAPI.Data;

public partial class Bait
{
    public int BaitId { get; set; }

    public string BaitType { get; set; } = null!;

    public string BestTimeOfYear { get; set; } = null!;
}
