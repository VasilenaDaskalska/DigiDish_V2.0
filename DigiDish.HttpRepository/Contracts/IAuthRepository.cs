using DigiDish.BusinessModels.Users;

namespace DigiDish.HttpRepository.Contracts
{
    public interface IAuthRepository
    {
        Task<UserBiz> ValidateUserCredentialsAsync(string username, string password);
    }
} 