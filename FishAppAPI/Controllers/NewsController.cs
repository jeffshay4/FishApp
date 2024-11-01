using FishAppAPI.Repositories;
using FishAppAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FishAppAPI.Controllers
{
    // Configures routing and API behavior for this controller
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService NewsService;

        // Constructor for NewsController, injects an INewsService instance for handling news-related operations
        public NewsController(INewsService NewsService)
        {
            this.NewsService = NewsService;
        }

        // HTTP POST endpoint for adding a new news item to the database
        [HttpPost("AddNews")]
        public async Task<IActionResult> AddNews(ExtFishingNews news)
        {
            // Checks if the news object provided in the request is null
            if (news == null)
            {
                return BadRequest(); // Returns a 400 Bad Request response if null
            }

            try
            {
                // Calls the AddNews method in INewsService to add the news item
                var response = await NewsService.AddNews(news);

                // Returns a 200 OK response with the response data from the service
                return Ok(response);
            }
            catch
            {
                // If an error occurs, the exception is rethrown to be handled by the global exception handler
                throw;
            }
        }
    }
}



