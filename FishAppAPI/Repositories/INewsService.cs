using FishAppAPI.Data;
using Microsoft.Data.SqlClient;
using FishAppAPI.Repositories;

namespace FishAppAPI.Repositories
{
    // INewsService interface defines the contract for the NewsService.
    public interface INewsService
    {
        // Method declaration for adding a news item, taking an ExtFishingNews object and returning an integer.
        // The integer result typically represents the status or result of the database operation.
        Task<int> AddNews(ExtFishingNews news);
    }
}

