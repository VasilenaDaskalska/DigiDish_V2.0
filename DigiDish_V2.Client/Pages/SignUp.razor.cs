using DigiDish.BusinessModels.Users;
using DigiDish.HttpRepository.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace DigiDish_V2.Client.Pages
{
    public partial class SignUp
    {
        private MudForm form;
        private bool success;
        private string ImageUrl { get; set; }
        private string FullName { get; set; }
        private string Username { get; set; }
        private string PhoneNumber { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }
        private string ConfirmPassword { get; set; }
        private bool passwordVisible;
        private InputType passwordInput = InputType.Password;
        private string passwordIcon = Icons.Material.Filled.VisibilityOff;
        private byte[] imageData;

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private ISnackbar Snackbar { get; set; }

        [Inject]
        private IUserHttpRepository UserHttpRepository { get; set; }

        private async Task UploadImage(InputFileChangeEventArgs e)
        {
            try
            {
                var file = e.File;
                if (file != null)
                {
                    var resizedImage = await file.RequestImageFileAsync("image/jpg", 300, 300);
                    this.imageData = new byte[resizedImage.Size];
                    await resizedImage.OpenReadStream().ReadAsync(this.imageData);
                    this.ImageUrl = $"data:image/jpg;base64,{Convert.ToBase64String(this.imageData)}";
                    this.StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                this.Snackbar.Add("Error uploading image. Please try again.", Severity.Error);
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

        private async Task ClearFormAsync()
        {
            this.ImageUrl = null;
            this.imageData = null;
            this.FullName = null;
            this.Username = null;
            this.PhoneNumber = null;
            this.Email = null;
            this.Password = null;
            this.ConfirmPassword = null;
            await this.form.ResetAsync();
            this.StateHasChanged();
        }

        private async Task HandleSignUp()
        {
            await this.form.Validate();

            if (this.form.IsValid)
            {
                if (this.Password != this.ConfirmPassword)
                {
                    this.Snackbar.Add("Passwords do not match!", Severity.Error);
                    return;
                }

                try
                {
                    var newUser = new UserBiz
                    {
                        Name = this.FullName,
                        UserName = this.Username,
                        PhoneNumber = this.PhoneNumber,
                        Email = this.Email,
                        Password = this.Password,
                        ProfilePhoto = this.imageData,
                    };

                    var registeredUser = await this.UserHttpRepository.RegisterUserAsync(newUser);

                    if (registeredUser != null)
                    {
                        this.Snackbar.Add("Successfully registered! Please sign in.", Severity.Success);
                        this.NavigationManager.NavigateTo("/SignIn");
                    }
                }
                catch (Exception ex)
                {
                    this.Snackbar.Add("An error occurred during registration. Please try again.", Severity.Error);
                }
            }
        }
    }
}