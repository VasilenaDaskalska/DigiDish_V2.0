using Blazored.LocalStorage;
using DigiDish.BusinessModels.ENUMS;
using DigiDish.HttpRepository.Contracts;
using DigiDish.Mappers;
using DigiDish_V2.Client.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DigiDish_V2.Client.Pages
{
    public partial class SignIn
    {
        private MudForm form;
        private bool success;
        private string Username { get; set; }
        private string Password { get; set; }
        private bool passwordVisible;
        private InputType passwordInput = InputType.Password;
        private string passwordIcon = Icons.Material.Filled.VisibilityOff;

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private ISnackbar Snackbar { get; set; }

        [Inject]
        private IUserHttpRepository UserHttpRepository { get; set; }

        [Inject]
        private ILocalStorageService LocalStorage { get; set; }

        [Inject]
        private UserState UserState { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (this.UserState.IsAuthenticated)
            {
                this.NavigationManager.NavigateTo("/Dashboard");
            }
        }
        private void TogglePasswordVisibility()
        {
            if (this.passwordVisible)
            {
                this.passwordVisible = false;
                this.passwordInput = InputType.Password;
                this.passwordIcon = Icons.Material.Filled.VisibilityOff;
            }
            else
            {
                this.passwordVisible = true;
                this.passwordInput = InputType.Text;
                this.passwordIcon = Icons.Material.Filled.Visibility;
            }
        }

        private async Task HandleSignIn()
        {
            await this.form.Validate();

            if (this.form.IsValid)
            {
                try
                {
                    var result = await this.UserHttpRepository.SignInAsync(this.Username, this.Password);

                    if (result.Success)
                    {
                        // Store the token in local storage
                        await this.LocalStorage.SetItemAsync("authToken", result.Token);
                        await this.LocalStorage.SetItemAsync("user", result.User);
                        if (result.User.UserPermission == PERMISSIONS.Admin)
                        {
                            await this.UserState.SetUserAsync(UserMapper.MapUserEntityWithAdminFromUserBiz(result.User));
                        }
                        else
                        {
                            await this.UserState.SetUserAsync(UserMapper.MapUserEntityFromUserBiz(result.User));
                        }

                        this.Snackbar.Add("Successfully signed in!", Severity.Success);
                        this.NavigationManager.NavigateTo("/Dashboard");
                    }
                    else
                    {
                        this.Snackbar.Add(result.Message, Severity.Error);
                    }
                }
                catch (Exception ex)
                {
                    this.Snackbar.Add("An error occurred while signing in.", Severity.Error);
                }
            }
        }
    }
}
