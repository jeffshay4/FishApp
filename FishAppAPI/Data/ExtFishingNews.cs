using System;
using System.Collections.Generic;

namespace FishingWebAppAPI.Data;

public partial class ExtFishingNews
{
    public int NewsId { get; set; }

    public string NewsDetails { get; set; } = null!;
}
