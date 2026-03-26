using Microsoft.EntityFrameworkCore;
using RandomUserApi.Data;
using RandomUserApi.Dtos;


namespace RandomUserApi.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserByUsernameAsync(string username);
    }
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto?> GetUserByUsernameAsync(string username)
        {
            var user = await _context.users
                .Include(u => u.Login)                   
                .FirstOrDefaultAsync(u => u.Login.Username == username);  


            if (user == null)
                return null;

            return new UserDto
            {
                UserId = user.Id,
                FullName = $"{user.Title} {user.First} {user.Last}",
                Gender = user.Gender,
                Email = user.Email,
                Phone = user.Phone,
                Cell = user.Cell,
                DateOfBirth = $"{user.DobDate}",
                DobAge = user.DobAge,
                Nationality = user.Nationality,
                RegisteredDate = $"{user.RegisteredDate}",
                RegisteredAge = user.RegisteredAge,
                IdName = user.IdName,
                IdValue = user.IdValue,
                PictureMediumUrl = user.PictureMediumUrl,
                PictureLargeUrl = user.PictureLargeUrl,
                PictureThumbnailUrl = user.PictureThumbnailUrl,
            };
        }
    }

}
