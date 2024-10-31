using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FishAppAPI.Data;

public partial class FishingWebAppContext : DbContext
{
    public FishingWebAppContext()
    {
    }

    public FishingWebAppContext(DbContextOptions<FishingWebAppContext> options)
        : base(options)
    {
    }


    public virtual DbSet<ExtFishingLocation> ExtFishingLocations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WeatherDatum> WeatherData { get; set; }

    public virtual DbSet<WebRating> WebRatings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
   

        modelBuilder.Entity<ExtFishingLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__ext_fish__E7FEA477CC4815A2");

            entity.ToTable("ext_fishing_locations");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Boat).HasColumnName("boat");
            entity.Property(e => e.Depth)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("depth");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.State)
                .HasMaxLength(255)
                .HasColumnName("state");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83F0C40E156");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FavoriteLocationId).HasColumnName("Favorite_Location_ID");
            entity.Property(e => e.Gender)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PasswordU)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Password_U");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("User_name");

            entity.HasOne(d => d.FavoriteLocation).WithMany(p => p.Users)
                .HasForeignKey(d => d.FavoriteLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user__Favorite_L__403A8C7D");
        });

        modelBuilder.Entity<WeatherDatum>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__WeatherD__E7FEA47762B70AD5");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.WeatherConditions).HasMaxLength(100);
        });

        modelBuilder.Entity<WebRating>(entity =>
        {
            entity.HasKey(e => e.WebRatingId).HasName("PK__web_rati__49A829E3D45D695D");

            entity.ToTable("web_rating");

            entity.Property(e => e.WebRatingId)
                .ValueGeneratedNever()
                .HasColumnName("web_rating_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
