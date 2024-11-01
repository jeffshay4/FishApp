using System;
using System.Collections.Generic;
using FishAppAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace FishingWebAppAPI.Data;

public partial class FishingWebAppContext : DbContext
{
    public FishingWebAppContext()
    {
    }

    public FishingWebAppContext(DbContextOptions<FishingWebAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Bait> Baits { get; set; }

    public virtual DbSet<ExtFishType> ExtFishTypes { get; set; }

    public virtual DbSet<ExtFishingLocation> ExtFishingLocations { get; set; }

    public virtual DbSet<ExtFishingNews> ExtFishingNews { get; set; }

    public virtual DbSet<FishingYear> FishingYears { get; set; }

    public virtual DbSet<Record> Records { get; set; }

    public virtual DbSet<WeatherDatum> WeatherData { get; set; }

    public virtual DbSet<WebRating> WebRatings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Bait>(entity =>
        {
            entity.HasKey(e => e.BaitId).HasName("PK__Bait__C2C72C40FB4689DC");

            entity.ToTable("Bait");

            entity.Property(e => e.BaitId).HasColumnName("BaitID");
            entity.Property(e => e.BaitType).HasMaxLength(50);
            entity.Property(e => e.BestTimeOfYear).HasMaxLength(50);
        });

        modelBuilder.Entity<ExtFishType>(entity =>
        {
            entity.HasKey(e => e.FishId).HasName("PK__ext_fish__F82A5BF94412F5CD");

            entity.ToTable("ext_fish_types");

            entity.Property(e => e.FishId).HasColumnName("FishID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.Location).WithMany(p => p.ExtFishTypes)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ext_fish___Locat__3F466844");
        });

        modelBuilder.Entity<ExtFishingLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__ext_fish__E7FEA477E4308B4E");

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

        modelBuilder.Entity<ExtFishingNews>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PK__ext_fish__954EBDF3F4A0B053");

            entity.ToTable("ext_fishing_news");

            entity.Property(e => e.NewsDetails).HasMaxLength(255);
        });

        modelBuilder.Entity<FishingYear>(entity =>
        {
            entity.HasKey(e => e.YearId).HasName("PK__FishingY__C33A18AD4F0BCBA6");

            entity.Property(e => e.YearId)
                .ValueGeneratedNever()
                .HasColumnName("YearID");
            entity.Property(e => e.GeneralObservations).HasMaxLength(255);
            entity.Property(e => e.NotableWeather).HasMaxLength(255);
        });

        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK__Records__603A0C6084757650");

            entity.Property(e => e.RecordId)
                .ValueGeneratedNever()
                .HasColumnName("Record_ID");
            entity.Property(e => e.BaitType)
                .HasMaxLength(255)
                .HasColumnName("Bait_Type");
            entity.Property(e => e.FishType)
                .HasMaxLength(255)
                .HasColumnName("Fish_Type");
            entity.Property(e => e.Length).HasMaxLength(255);
            entity.Property(e => e.LocationId).HasColumnName("Location_ID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Weight).HasMaxLength(255);
        });

        modelBuilder.Entity<WeatherDatum>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__WeatherD__E7FEA47789C7CF7D");

            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.WeatherConditions).HasMaxLength(100);
        });

        modelBuilder.Entity<WebRating>(entity =>
        {
            entity.HasKey(e => e.WebRatingId).HasName("PK__web_rati__49A829E3823F455B");

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
