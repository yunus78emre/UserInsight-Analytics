using RandomUserApi.Data;
using RandomUserApi.Dtos;
using RandomUserApi.Models;
using System.Security.Cryptography;

namespace RandomUserApi.Services
{
    public interface ICreateService
    {
        Task<User> CreateUserAsync(CreateUserDto dto);
    }

    public class CreateService : ICreateService
    {
        private readonly ApplicationDbContext _context;

        public CreateService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(CreateUserDto dto)
        {
            try
            {
                var uuid = Guid.NewGuid();
                var salt = GenerateSalt();
                var md5 = GenerateMd5();
                var sha1 = GenerateSha1();
                var sha256 = GenerateSha256();

                var login = new Login
                {
                    Username = dto.Username,
                    Password = dto.Password,
                    Uuid = uuid,
                    Salt = salt,
                    Md5 = md5,
                    Sha1 = sha1,
                    Sha256 = sha256
                };

                var location = new Location
                {
                    
                    StreetName = dto.StreetName,
                    City = dto.City,
                    State = dto.State,
                    Country = dto.Country,
                    
                };

                await _context.login.AddAsync(login);
                await _context.location.AddAsync(location);
                await _context.SaveChangesAsync();

                var dobDateUtc = dto.DobDate.Kind == DateTimeKind.Unspecified
                    ? DateTime.SpecifyKind(dto.DobDate, DateTimeKind.Utc)
                    : dto.DobDate.ToUniversalTime();

                var user = new User
                {
                    Gender = dto.Gender,
                    Title = dto.Title,
                    First = dto.First,
                    Last = dto.Last,
                    Email = dto.Email,
                    Phone = dto.Phone,
                    Cell = dto.Cell,
                    DobDate = dobDateUtc,
                    DobAge = dto.DobAge,
                    RegisteredDate = DateTime.UtcNow,
                    RegisteredAge = dto.RegisteredAge,
                    Nationality = dto.Nationality,
                    LoginId = login.Id,
                    LocationId = location.Id,

                    PictureLargeUrl = GetRandomPicture(dto.Gender, "large"),
                    PictureMediumUrl = GetRandomPicture(dto.Gender, "medium"),
                    PictureThumbnailUrl = GetRandomPicture(dto.Gender, "thumbnail")
                };

                await _context.users.AddAsync(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine("CreateUserAsync hata: " + ex.Message);
                Exception inner = ex.InnerException;
                while (inner != null)
                {
                    Console.WriteLine("Inner Exception: " + inner.Message);
                    inner = inner.InnerException;
                }
                throw;
            }
        }

        private static string GenerateSalt(int size = 8)
        {
            byte[] saltBytes = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        private static string GenerateMd5(int size = 32)
        {
            byte[] md5Bytes = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(md5Bytes);
            return Convert.ToBase64String(md5Bytes);
        }

        private static string GenerateSha1(int size = 32)
        {
            byte[] sha1Bytes = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(sha1Bytes);
            return Convert.ToBase64String(sha1Bytes);
        }

        private static string GenerateSha256(int size = 32)
        {
            byte[] sha256Bytes = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(sha256Bytes);
            return Convert.ToBase64String(sha256Bytes);
        }

        private static string GetRandomPicture(string gender, string size)
        {
            var random = new Random();
            int index = random.Next(0, 100); 

            string baseUrl = size switch
            {
                "large" => "https://randomuser.me/api/portraits/",
                "medium" => "https://randomuser.me/api/portraits/med/",
                "thumbnail" => "https://randomuser.me/api/portraits/thumb/",
                _ => "https://randomuser.me/api/portraits/"
            };

            string genderFolder = gender?.ToLower() == "female" ? "women" : "men";

            return $"{baseUrl}{genderFolder}/{index}.jpg";
        }
    }
}
