using DigiDish.BusinessModels;
using DigiDish.BusinessModels.Users;

namespace DigiDish.HttpRepository.Contracts
{
    public interface IUserHttpRepository
    {
        Task<UserBiz> RegisterUserAsync(UserBiz user);

        Task<bool> ChangePasswordAsync(long userId, string newPassword);

        Task<IEnumerable<UserBiz>> GetAllAsync();

        Task<UserBiz> GetByIdAsync(long id);

        Task UpdateAsync(UserBiz user);

        Task<bool> DeleteAsync(long id);

        Task<SignInResponse> SignInAsync(string username, string password);
    }
}
