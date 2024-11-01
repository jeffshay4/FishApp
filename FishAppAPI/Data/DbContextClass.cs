using FishAppAPI.Data;
using FishingWebAppAPI.Data;
using Microsoft.EntityFrameworkCore;
namespace FishAppAPI.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<ExtFishingLocation> ExtFishingLocation { get; set; }
        public DbSet<ExtFishingNews> ExtFishingNews { get; set; }
        
    
    }
}
