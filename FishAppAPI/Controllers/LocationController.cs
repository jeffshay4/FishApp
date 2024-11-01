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
    public class LocationController : ControllerBase
    {
        private readonly ILocationService LocationService;

        // Constructor for LocationController, injects an ILocationService instance for handling location-related operations
        public LocationController(ILocationService LocationService)
        {
            this.LocationService = LocationService;
        }

        // HTTP GET endpoint for retrieving details of a specific location based on LocationId
        [HttpGet("locationdetailsget")]
        public async Task<IEnumerable<ExtFishingLocation>> LocationDetailsGet(int LocationId)
        {
            try
            {
                // Calls the LocationDetailsGet method in ILocationService to get location details
                var response = await LocationService.LocationDetailsGet(LocationId);

                // Checks if response is null, indicating no location was found
                if (response == null)
                {
                    return null; // Returns null if no details are found
                }

                // Returns the location details if found
                return response;
            }
            catch
            {
                // If an error occurs, the exception is rethrown to be handled by the global exception handler
                throw;
            }
        }
    }
}

