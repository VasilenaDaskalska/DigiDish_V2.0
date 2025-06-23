using DigiDish.BusinessModels;

namespace DigiDish.Services.Contracts
{
    public interface IAuthService
    {
        Task<SignInResponse> SignInAsync(SignInRequest request);
    }
}