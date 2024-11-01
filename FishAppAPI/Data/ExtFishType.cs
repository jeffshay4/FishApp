using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishAppAPI.Data;

public partial class ExtFishType
{
    [Key]
    public int FishId { get; set; }

    public string Name { get; set; } = null!;
    [ForeignKey("ExtFishingLocation")]
    public int LocationId { get; set; }

    public virtual ExtFishingLocation Location { get; set; } = null!;
}
