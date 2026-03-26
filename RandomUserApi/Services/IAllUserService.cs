using Microsoft.EntityFrameworkCore;
using RandomUserApi.Data;
using RandomUserApi.Models;
using RandomUserApi.Dtos;

namespace RandomUserApi.Services
{
    public interface IAllUserService
    {
        Task<PagedResult<AllUserDto>> GetAllUsersAsync(string? gender, string? nationality, int pageNumber, int pageSize);
        Task<List<string>> GetAllNationalitiesAsync();

    }

    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
    }


    public class AllUserService : IAllUserService
    {
        private readonly ApplicationDbContext _context;

        public AllUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetAllNationalitiesAsync()
        {
            return await _context.users
                .Select(u => u.Nationality)
                .Distinct()
                .ToListAsync();
        }


        public async Task<PagedResult<AllUserDto>> GetAllUsersAsync(string? gender, string? nationality, int pageNumber, int pageSize)
        {
            var query = _context.users.Include(u => u.Location).AsQueryable();

            if (!string.IsNullOrEmpty(gender))
            {
                var genderLower = gender.ToLower();
                query = query.Where(u => u.Gender.ToLower() == genderLower);
            }

            if (!string.IsNullOrEmpty(nationality))
            {
                var nationalityLower = nationality.ToLower();
                query = query.Where(u => u.Nationality.ToLower() == nationalityLower);
            }

            var totalCount = await query.CountAsync();

            var users = await query
                .OrderByDescending(u => u.RegisteredDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var userDtos = users.Select(u => new AllUserDto
            {
                UserId = u.Id,
                FullName = $"{u.Title} {u.First} {u.Last}",
                Gender = u.Gender,
                Email = u.Email,
                Phone = u.Phone,
                Cell = u.Cell,
                Nationality = u.Nationality,
                PictureMediumUrl = u.PictureMediumUrl,
                PictureLargeUrl = u.PictureLargeUrl,
                PictureThumbnailUrl = u.PictureThumbnailUrl,
                StreetName = u.Location?.StreetName,
                City = u.Location?.City,
                State = u.Location?.State,
                Country = u.Location?.Country,
            }).ToList();

            return new PagedResult<AllUserDto>
            {
                Items = userDtos,
                TotalCount = totalCount
            };
        }

    }
}
