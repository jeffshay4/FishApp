using System;
using System.Collections.Generic;

namespace FishingWebAppAPI.Data;

public partial class FishingYear
{
    public int YearId { get; set; }

    public int Year { get; set; }

    public string? NotableWeather { get; set; }

    public string? GeneralObservations { get; set; }
}
