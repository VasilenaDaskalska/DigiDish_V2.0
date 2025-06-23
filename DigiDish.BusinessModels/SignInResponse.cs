using DigiDish.BusinessModels.Users;

namespace DigiDish.BusinessModels
{
    public class SignInResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public UserBiz User { get; set; }
    }
}
