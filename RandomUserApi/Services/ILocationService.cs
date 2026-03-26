using RandomUserApi.Data;
using RandomUserApi.Models;

namespace RandomUserApi.Services
{
    public interface ILocationService
    {
        
            Task<Location> GetLocationByUserIdAsync(int userId);

    }
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext _context;

        public LocationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Location> GetLocationByUserIdAsync(int userId)
        {
            var user = await _context.users.FindAsync(userId);
            if (user == null) return null;

            return await _context.location.FindAsync(user.LocationId);
        }
    }

}
