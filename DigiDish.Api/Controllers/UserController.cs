using DigiDish.BusinessModels;
using DigiDish.BusinessModels.Users;
using DigiDish.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DigiDish.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IAuthService authService;

        public UserController(IUserService userService, IAuthService authService)
        {
            this.userService = userService;
            this.authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserBiz newUser)
        {
            try
            {
                var createdUser = await this.userService.RegisterUserAsync(newUser);
                return this.Ok(createdUser);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePasswordAsync(long userId, string newPassword)
        {
            try
            {
                bool isPasswordChanged = await this.userService.ChangePasswordAsync(userId, newPassword);
                return this.Ok(isPasswordChanged);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await this.userService.GetAllAsync();

                if (users == null)
                {
                    return this.NotFound();
                }

                return this.Ok(users);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var user = await this.userService.GetByIdAsync(id);

                if (user == null)
                {
                    return this.NotFound();
                }

                return this.Ok(user);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

        }

        [HttpPut("update-user")]
        public async Task<IActionResult> Update([FromBody] UserBiz model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.BadRequest(this.ModelState);
                }

                var updated = await this.userService.EditUserAsync(model);

                if (updated == null)
                {
                    return this.NotFound();
                }

                return this.Ok(updated);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await this.userService.DeleteUserAsync(id);

                if (!result)
                {
                    return this.NotFound();
                }

                return this.NoContent();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            try
            {
                var result = await this.authService.SignInAsync(request);
                if (result.Success)
                {
                    return this.Ok(result);
                }
                return this.BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
