using FishAppAPI.Data;

namespace FishAppAPI.Repositories
{
    public interface ILocationService
    {
        Task<IEnumerable<ExtFishingLocation>> LocationDetailsGet(int LocationId);
    }
}
