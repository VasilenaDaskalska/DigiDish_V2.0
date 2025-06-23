using DigiDish.BusinessModels.Helpers;
using DigiDish.BusinessModels.Users;
using DigiDish.Entities.Context;
using DigiDish.HttpRepository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DigiDish.HttpRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DigiDishDbContext _context;

        public AuthRepository(DigiDishDbContext context)
        {
            this._context = context;
        }

        public async Task<UserBiz> ValidateUserCredentialsAsync(string username, string password)
        {
            string hashedPassword = string.Empty;

            if (username != "Admin")
            {
                // Hash the password for comparison
                hashedPassword = PasswordHelper.HashPasswordSHA512(password);
            }
            else
            {
                hashedPassword = password;
            }

            // Find user by username or email
            var user = await this._context.Users
                .FirstOrDefaultAsync(u =>
                    (u.UserName == username || u.Email == username) &&
                    u.Password == hashedPassword &&
                    !u.IsDeleted);

            if (user == null)
                return null;

            // Map User entity to UserBiz
            return new UserBiz
            {
                ID = user.ID,
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ProfilePhoto = user.ProfilePhoto,
                CreationDate = user.CreationDate,
                LastModifiedDate = user.LastModifiedDate,
                LastPasswordModifiedDate = user.LastPasswordModifiedDate,
                IsDeleted = user.IsDeleted,
                UserPermission = user.UserPermissions,
            };
        }
    }
}