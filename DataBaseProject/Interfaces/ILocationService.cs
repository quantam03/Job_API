using DataBaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseProject.Interfaces
{
    public interface ILocationService
    {
        Task<List<Location>> GetAllLocation();

        Task<Location> GetLocationById(int id);

        Task<Location> CreateLocation(Location location);
    }
}
