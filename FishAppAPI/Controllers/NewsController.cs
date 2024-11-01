using FishAppAPI.Repositories;
using FishAppAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace FishAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService NewsService;
        public NewsController(INewsService NewsService)
        {
            this.NewsService = NewsService;
        }
        [HttpPost("AddNews")]

        public async Task<IActionResult> AddNews(ExtFishingNews news)
        {
            if (news == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await NewsService.AddNews(news);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
    }
}

