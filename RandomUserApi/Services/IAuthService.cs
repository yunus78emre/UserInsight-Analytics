using Microsoft.EntityFrameworkCore;
using RandomUserApi.Data;

namespace RandomUserApi.Services
{
    public interface IAuthService
    {
        Task<bool> ValidateLoginAsync(string username, string password);

    }

    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidateLoginAsync(string username, string password)
        {
            return await _context.login
                .AnyAsync(x => x.Username == username && x.Password == password);
        }
    }

}
