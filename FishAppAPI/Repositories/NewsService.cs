using FishAppAPI.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FishAppAPI.Repositories
{
    // This class implements the INewsService interface, providing methods to interact with the database for news-related operations.
    public class NewsService : INewsService
    {
        private readonly DbContextClass _dbContext;

        // Constructor for NewsService, initializes the _dbContext with the provided DbContextClass instance.
        public NewsService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        // Adds a news item to the database by calling a stored procedure.
        public async Task<int> AddNews(ExtFishingNews news)
        {
            // Create a list of SqlParameter objects to store parameters for the stored procedure.
            var parameter = new List<SqlParameter>();

            // Add NewsId and NewsDetails as parameters for the stored procedure.
            parameter.Add(new SqlParameter("@NewsId", news.NewsId));
            parameter.Add(new SqlParameter("@NewsDetails", news.NewsDetails));

            // Execute the stored procedure (spAddNews) with the specified parameters asynchronously
            return await _dbContext.Database.ExecuteSqlRawAsync("exec spAddNews @NewsId, @NewsDetails", parameter.ToArray());
        }
    }
}

