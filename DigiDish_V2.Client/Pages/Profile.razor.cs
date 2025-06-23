using Blazored.LocalStorage;
using DigiDish.BusinessModels;
using DigiDish.BusinessModels.Users;
using DigiDish.HttpRepository.Contracts;
using DigiDish.Mappers;
using DigiDish_V2.Client.Services;
using DigiDish_V2.Client.Shared.Dialogs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace DigiDish_V2.Client.Pages
{
    public partial class Profile
    {
        private MudForm form;
        private bool success;

        private byte[]? imageData;

        [Inject]
        private ISnackbar Snackbar { get; set; }

        [Inject]
        private IUserHttpRepository UserHttpRepository { get; set; }

        [Inject]
        private UserState UserState { get; set; }

        [Inject]
        private ILocalStorageService LocalStorage { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        private UserBiz CurrentUser { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.CurrentUser = await this.UserHttpRepository.GetByIdAsync(this.UserState.CurrentUser.ID);

            if (this.CurrentUser == null)
            {
                return;
            }
        }

        private string GetImageUrl()
        {
            if (this.imageData == null)
            {
                return null;
            }
            return $"data:image/jpg;base64,{Convert.ToBase64String(this.imageData)}";
        }

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
                    this.StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                this.Snackbar.Add("Error uploading image. Please try again.", Severity.Error);
            }
        }

        private async Task ClearFormAsync()
        {
            await this.OnInitializedAsync();
            await this.form.ResetAsync();
        }

        private async Task ChangePasswordAsync()
        {
            var dialog = await this.DialogService.ShowAsync<ChangePasswordDialog>("Change Password");
            var result = await dialog.Result;

            if (!result.Canceled)
            {
                var passwordChange = (PasswordChangeModel)result.Data;
                try
                {
                    // Here you might want to add an endpoint to verify current password before changing
                    await this.UserHttpRepository.ChangePasswordAsync(this.CurrentUser.ID, passwordChange.NewPassword);
                    this.CurrentUser.Password = passwordChange.NewPassword;
                    this.Snackbar.Add("Password changed successfully!", Severity.Success);
                }
                catch (Exception ex)
                {
                    this.Snackbar.Add("Failed to change password. Please try again.", Severity.Error);
                }
            }
        }

        private async Task SaveChangesAsync()
        {
            await this.form.Validate();

            if (this.form.IsValid)
            {
                try
                {
                    this.CurrentUser.ProfilePhoto = this.imageData;
                    await this.UserHttpRepository.UpdateAsync(this.CurrentUser);
                    var sessionUser = UserMapper.MapUserEntityFromUserBiz(this.CurrentUser);
                    await this.UserState.SetUserAsync(sessionUser);
                    await this.LocalStorage.SetItemAsync("user", this.CurrentUser);

                    this.Snackbar.Add("Profile updated successfully!", Severity.Success);
                }
                catch (Exception ex)
                {
                    this.Snackbar.Add("Failed to update profile. Please try again.", Severity.Error);
                }
            }
        }
    }
}
