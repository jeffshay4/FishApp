using FishAppAPI.Data;

namespace FishAppAPI.Repositories
{
    // ILocationService interface defines the contract for the LocationService.
    public interface ILocationService
    {
        // Method declaration for retrieving location details based on a LocationId.
        // Returns an IEnumerable of ExtFishingLocation objects as a Task.
        Task<IEnumerable<ExtFishingLocation>> LocationDetailsGet(int LocationId);
    }
}

