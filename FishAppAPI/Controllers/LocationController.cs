using FishAppAPI.Repositories;
using FishAppAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace FishAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService LocationService;
        public LocationController(ILocationService LocationService)
        {
            this.LocationService = LocationService;
        }
        [HttpGet("locationdetailsget")]
        public async Task<IEnumerable<ExtFishingLocation>> LocationDetailsGet(int LocationId)
        {
            try
            {
                var response = await LocationService.LocationDetailsGet(LocationId);
                if (response == null)
                {
                    return null;
                }
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
