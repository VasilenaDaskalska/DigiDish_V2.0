using DigiDish.BusinessModels.Measures;
using DigiDish.HttpRepository.Contracts;
using DigiDish_V2.Client.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DigiDish_V2.Client.Shared.Dialogs
{
    public partial class AddorEditMeasureDialog
    {
        private MudForm form;
        private bool success;

        [CascadingParameter]
        private IMudDialogInstance MudDialog { get; set; }

        [Parameter]
        public MeasureBiz Measure { get; set; }

        [Inject]
        private IMeasureHttpRepository MeasureHttpRepository { get; set; }

        [Inject]
        private UserState UserState { get; set; }

        [Inject]
        private ISnackbar Snackbar { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        private async Task ClearFormAsync()
        {
            await this.form.ResetAsync();
        }

        private async Task SaveAsync()
        {
            await this.form.Validate();

            if (this.form.IsValid && this.Measure != null)
            {
                this.Measure.CreationDate = DateTime.Now;
                this.Measure.LastModifiedDate = DateTime.Now;
                this.Measure.LastUserModifiedID = this.UserState.CurrentUser?.ID ?? 0;

                if (this.Measure.ID > 0)
                {
                    try
                    {
                        await this.MeasureHttpRepository.UpdateAsync(this.Measure);
                    }
                    catch (Exception ex)
                    {
                        this.Snackbar.Add("Failed to update measure. Please try again.", Severity.Error);
                        return;
                    }

                }
                else
                {
                    this.Measure.UserCreatorID = this.UserState.CurrentUser?.ID ?? 0;

                    var response = await this.MeasureHttpRepository.CreateAsync(this.Measure);

                    if (response != null)
                    {
                        this.Measure = response;
                    }
                    else
                    {
                        this.Snackbar.Add("Failed to add measure. Please try again.", Severity.Error);
                        return;
                    }
                }


                this.MudDialog.Close(DialogResult.Ok(this.Measure));
            }
        }

        private async Task CancelAsync()
        {
            this.MudDialog.Cancel();
        }
    }
}
