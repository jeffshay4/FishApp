using FishAppAPI.Data;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FishAppAPI.Repositories
{
    public class LocationService : ILocationService
    {
        private readonly DbContextClass _dbContext;
        public LocationService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ExtFishingLocation>> LocationDetailsGet(int LocationId)
        {
            var param = new SqlParameter("@LocationId", LocationId);
            var locationDetails = await Task.Run(() => _dbContext.ExtFishingLocation
                .FromSqlRaw(@"exec spLocationDetailsGet @LocationId", param).ToListAsync());
            return locationDetails;
        }
    }
}
