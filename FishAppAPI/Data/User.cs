using System;
using System.Collections.Generic;

namespace FishAppAPI.Data;

public partial class User
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string PasswordU { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int FavoriteLocationId { get; set; }

    public virtual ExtFishingLocation FavoriteLocation { get; set; } = null!;
}
