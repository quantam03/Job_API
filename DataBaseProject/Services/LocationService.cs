using DataBaseProject.DatabaseContext;
using DataBaseProject.Interfaces;
using DataBaseProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseProject.Services
{
    public class LocationService : ILocationService
    {
        private readonly SqlServerContext _dBcontext;
        public LocationService(SqlServerContext dbcontext)
        {
            _dBcontext = dbcontext;
        }
        /// <summary>
        /// Get list of location
        /// </summary>
        /// <returns></returns>
        public async Task<List<Location>> GetAllLocation()
        {
            try
            {
                var location = await _dBcontext.Location.ToListAsync();


                return location;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw ex;
            }
        }

        /// <summary>
        /// Get location by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Location> GetLocationById(int id)
        {
            try
            {
                var location = await _dBcontext.Location
                    .FirstOrDefaultAsync(d => d.LocationId == id);

                return location;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw ex;
            }
        }

        /// <summary>
        /// Add new Location 
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public async Task<Location> CreateLocation(Location location)
        {
            try
            {
                // Add the department to the DbSet
                _dBcontext.Location.Add(location);

                // Save changes to the database
                await _dBcontext.SaveChangesAsync();

                return location;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw ex;
            }
        }

    }
}
