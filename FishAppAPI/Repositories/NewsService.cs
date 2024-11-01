using FishAppAPI.Data;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FishAppAPI.Repositories
{
    public class NewsService : INewsService
    {
        private readonly DbContextClass _dbContext;
        public NewsService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddNews(ExtFishingNews news)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@NewsId", news.NewsId));
            parameter.Add(new SqlParameter("@NewsDetails", news.NewsDetails));

            return await _dbContext.Database.ExecuteSqlRawAsync("exec spAddNews @NewsId, @NewsDetails", parameter.ToArray());
        }
        }
    } 
