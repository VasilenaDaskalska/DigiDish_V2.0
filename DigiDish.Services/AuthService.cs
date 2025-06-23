using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DigiDish.BusinessModels;
using DigiDish.BusinessModels.Users;
using DigiDish.HttpRepository.Contracts;
using DigiDish.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DigiDish.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IAuthRepository authRepository, IConfiguration configuration)
        {
            this._authRepository = authRepository;
            this._configuration = configuration;
        }

        public async Task<SignInResponse> SignInAsync(SignInRequest request)
        {
            var user = await this._authRepository.ValidateUserCredentialsAsync(request.Username, request.Password);

            if (user == null)
            {
                return new SignInResponse
                {
                    Success = false,
                    Message = "Invalid username or password"
                };
            }

            // Generate JWT token
            var token = this.GenerateJwtToken(user);

            return new SignInResponse
            {
                Success = true,
                Message = "Successfully signed in",
                Token = token,
                User = user
            };
        }

        private string GenerateJwtToken(UserBiz user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(this._configuration["JwtSettings:ExpirationInDays"]));

            var token = new JwtSecurityToken(
                issuer: this._configuration["JwtSettings:Issuer"],
                audience: this._configuration["JwtSettings:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}