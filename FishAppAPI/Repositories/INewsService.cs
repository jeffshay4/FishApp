using FishAppAPI.Data;
using Microsoft.Data.SqlClient;
using FishAppAPI.Repositories;

namespace FishAppAPI.Repositories
{
    public interface INewsService
    {
        Task<int> AddNews(ExtFishingNews news);
    }  
 }
