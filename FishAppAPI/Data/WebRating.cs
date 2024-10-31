using System;
using System.Collections.Generic;

namespace FishingWebAppAPI.Data;

public partial class WebRating
{
    public int WebRatingId { get; set; }

    public int UserId { get; set; }

    public int? Rating { get; set; }

    public string? Description { get; set; }
}
