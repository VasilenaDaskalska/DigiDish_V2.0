using DigiDish.BusinessModels.Helpers;
using DigiDish.BusinessModels.Users;
using DigiDish.Entities;
using DigiDish.Entities.AuditTriailEntities;
using DigiDish.HttpRepository.Contracts;
using DigiDish.Mappers;
using DigiDish.Services.Contracts;

namespace DigiDish.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<UserLog> userLogRepository;
        private readonly IRepository<AuditLog> auditLogRepository;

        public UserService(
            IRepository<User> userRepository,
            IRepository<UserLog> userLogRepository,
            IRepository<AuditLog> auditLogRepository)
        {
            this.auditLogRepository = auditLogRepository;
            this.userLogRepository = userLogRepository;
            this.userRepository = userRepository;
        }

        // Register a new user
        public async Task<UserBiz> RegisterUserAsync(UserBiz model)
        {
            try
            {
                // Check if the user already exists
                var existingUser = await this.userRepository.GetAllAsync();

                if (existingUser.Any(u => u.UserName == model.UserName || u.Email == model.Email))
                {
                    throw new Exception("Username or Email already exists.");
                }

                // Hash the password before saving
                var hashedPassword = PasswordHelper.HashPasswordSHA512(model.Password);
                model.Password = hashedPassword;
                User newUser = new User();

                UserMapper.MapUserEntityFromUserBiz(ref newUser, ref model);

                // Add the new user
                var result = await this.userRepository.AddAsync(newUser);

                return UserMapper.MapUserBizFromUserEntity(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to register new user {ex.Message}");
            }

        }

        // Change a user's password
        public async Task<bool> ChangePasswordAsync(long userId, string newPassword)
        {
            try
            {
                var user = await this.userRepository.GetByIdAsync(userId);

                if (user == null)
                {
                    return false; // User not found
                }

                // Hash the new password before saving
                user.Password = PasswordHelper.HashPasswordSHA512(newPassword);
                user.LastPasswordModifiedDate = DateTime.UtcNow;

                // Update the user entity
                await this.userRepository.UpdateAsync(user);

                await this.LogChange(user, userId);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update user's password {ex.Message}");
            }

        }

        // Edit user details
        public async Task<UserBiz> EditUserAsync(UserBiz model)
        {
            try
            {
                var user = await this.userRepository.GetByIdAsync(model.ID);

                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                model.Password = PasswordHelper.HashPasswordSHA512(model.Password);
                model.LastPasswordModifiedDate = DateTime.UtcNow;

                UserMapper.MapUserEntityFromUserBiz(ref user, ref model);

                await this.userRepository.UpdateAsync(user);
                await this.LogChange(user, 19);

                return await this.GetByIdAsync(model.ID);

            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update user {ex.Message}");
            }

        }

        // Soft delete user (set IsDeleted to true)
        public async Task<bool> DeleteUserAsync(long userId)
        {
            try
            {
                var user = await this.userRepository.GetByIdAsync(userId);
                if (user == null)
                {
                    return false; // User not found
                }

                user.IsDeleted = true;
                user.LastModifiedDate = DateTime.UtcNow;

                await this.userRepository.UpdateAsync(user);
                await this.LogChange(user, userId);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete user {ex.Message}");
            }
        }

        public async Task<UserBiz?> GetByIdAsync(long id)
        {
            try
            {
                var user = await this.userRepository.GetByIdAsync(id);
                return (user == null || user.IsDeleted)
                    ? null
                    : UserMapper.MapUserBizFromUserEntity(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get user {ex.Message}");
            }
        }

        public async Task<IEnumerable<UserBiz>> GetAllAsync()
        {
            try
            {
                var users = await this.userRepository.GetAllAsync();

                return users
                    .Where(p => !p.IsDeleted)
                    .Select(UserMapper.MapUserBizFromUserEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get users {ex.Message}");
            }
        }

        private async Task LogChange(User user, long userId)
        {
            var auditLog = new AuditLog(userId)
            {
                CreationDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow
            };

            var createdAuditLog = await this.auditLogRepository.AddAsync(auditLog);
            var userLog = new UserLog(user, userId)
            {
                AuditLogID = createdAuditLog.ID,
                UserID = user.ID,
            };

            await this.userLogRepository.AddAsync(userLog);
        }
    }
}
