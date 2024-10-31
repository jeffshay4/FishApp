using System;
using System.Collections.Generic;

namespace FishingWebAppAPI.Data;

public partial class Record
{
    public int RecordId { get; set; }

    public string? Name { get; set; }

    public string? FishType { get; set; }

    public string? Weight { get; set; }

    public string? Length { get; set; }

    public string? BaitType { get; set; }

    public int LocationId { get; set; }
}
