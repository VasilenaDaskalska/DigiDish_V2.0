using DigiDish.BusinessModels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DigiDish_V2.Client.Shared.Dialogs
{
    public partial class ChangePasswordDialog
    {
        [CascadingParameter]
        private IMudDialogInstance MudDialog { get; set; }

        private MudForm form;
        private bool success;

        private string CurrentPassword { get; set; }
        private string NewPassword { get; set; }
        private string ConfirmPassword { get; set; }

        // Current password visibility
        private bool currentPasswordVisible;
        private InputType currentPasswordInput = InputType.Password;
        private string currentPasswordIcon = Icons.Material.Filled.VisibilityOff;

        // New password visibility
        private bool newPasswordVisible;
        private InputType newPasswordInput = InputType.Password;
        private string newPasswordIcon = Icons.Material.Filled.VisibilityOff;

        // Confirm password visibility
        private bool confirmPasswordVisible;
        private InputType confirmPasswordInput = InputType.Password;
        private string confirmPasswordIcon = Icons.Material.Filled.VisibilityOff;

        private void TogglePasswordVisibility(ref bool visible, ref InputType inputType, ref string icon)
        {
            if (visible)
            {
                visible = false;
                inputType = InputType.Password;
                icon = Icons.Material.Filled.VisibilityOff;
            }
            else
            {
                visible = true;
                inputType = InputType.Text;
                icon = Icons.Material.Filled.Visibility;
            }
        }

        private async Task ClearFormAsync()
        {
            this.CurrentPassword = null;
            this.NewPassword = null;
            this.ConfirmPassword = null;
            await this.form.ResetAsync();
        }

        private async Task Submit()
        {
            await this.form.Validate();

            if (this.form.IsValid)
            {
                if (this.NewPassword != this.ConfirmPassword)
                {
                    return;
                }

                var result = new PasswordChangeModel
                {
                    CurrentPassword = this.CurrentPassword,
                    NewPassword = this.NewPassword
                };

                this.MudDialog.Close(DialogResult.Ok(result));
            }
        }

        private async Task CancelAsync()
        {
            this.MudDialog.Cancel();
        }
    }
}
