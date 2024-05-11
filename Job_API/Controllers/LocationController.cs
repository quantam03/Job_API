using DataBaseProject.Interfaces;
using DataBaseProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService) // Corrected constructor method name
        {
            _locationService = locationService;
        }



        /// <summary>
        /// Get All Location
        /// </summary>
        /// <returns></returns>

        [HttpGet("GetAllLocation")]
        public async Task<IActionResult> GetAllLocation()
        {
            try
            {
                var response = await _locationService.GetAllLocation();

                if (response == null) return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Location by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("GetLocationById")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            try
            {
                var response = await _locationService.GetLocationById(id);

                if (response == null) return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Add new location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpPut("CreateLocation")]
        public async Task<IActionResult> CreateLocation(Location location)
        {
            try
            {
                // Call the service method to create the department
                var addLocation = await _locationService.CreateLocation(location);

                // Return the created department in the response
                return Ok(addLocation);
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return BadRequest(ex.Message);
            }
        }
    }
}
