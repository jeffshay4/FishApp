using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishAppAPI.Data;

public partial class ExtFishingNews
{
    [Key]
    public int NewsId { get; set; }

    public string NewsDetails { get; set; } = null!;
}
