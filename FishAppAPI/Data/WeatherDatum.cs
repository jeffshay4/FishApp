using System;
using System.Collections.Generic;

namespace FishingWebAppAPI.Data;

public partial class WeatherDatum
{
    public int LocationId { get; set; }

    public string Name { get; set; } = null!;

    public int? Temperature { get; set; }

    public string? WeatherConditions { get; set; }
}
