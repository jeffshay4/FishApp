using FishAppAPI.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FishAppAPI.Repositories
{
    // This class implements the ILocationService interface and provides methods to interact with location data in the database.
    public class LocationService : ILocationService
    {
        private readonly DbContextClass _dbContext;

        // Constructor for LocationService, initializes _dbContext with the provided DbContextClass instance.
        public LocationService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        // Retrieves details of a specific location from the database by executing a stored procedure.
        public async Task<IEnumerable<ExtFishingLocation>> LocationDetailsGet(int LocationId)
        {
            // Creates a SqlParameter object for the LocationId parameter required by the stored procedure.
            var param = new SqlParameter("@LocationId", LocationId);

            // Executes the stored procedure (spLocationDetailsGet) using FromSqlRaw to retrieve the location details,
            // and then converts the result to a list asynchronously.
            var locationDetails = await Task.Run(() => _dbContext.ExtFishingLocation
                .FromSqlRaw(@"exec spLocationDetailsGet @LocationId", param).ToListAsync());

            // Returns the retrieved list of location details.
            return locationDetails;
        }
    }
}

