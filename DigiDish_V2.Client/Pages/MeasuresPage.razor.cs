using DigiDish.BusinessModels.Measures;
using DigiDish.HttpRepository.Contracts;
using DigiDish_V2.Client.Shared.Dialogs;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DigiDish_V2.Client.Pages
{
    public partial class MeasuresPage : IDisposable
    {
        private MeasureBiz selectedMeasure;
        private bool isSearching;
        private bool isSelectedMeasureLoading;
        private bool isLoading;

        public List<MeasureBiz> Measures { get; set; }

        [Inject]
        protected IMeasureHttpRepository MeasureHttpRepository { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        [Inject]
        private ISnackbar Snackbar { get; set; }

        public void Dispose()
        {

        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await this.InitMeasuresAsync();
        }

        private async Task InitMeasuresAsync()
        {
            this.selectedMeasure = new MeasureBiz();
            this.isLoading = true;
            var response = await this.MeasureHttpRepository.GetAllAsync();
            this.isLoading = false;
            if (response != null)
            {
                this.Measures = response?.ToList() ?? new List<MeasureBiz>();
            }
        }

        private async Task AddOrEditMeasure(MeasureBiz measureBiz)
        {
            var parameters = new DialogParameters { ["Measure"] = measureBiz };
            var dialog = this.DialogService.Show<AddorEditMeasureDialog>(string.Empty, parameters, new DialogOptions { NoHeader = true, MaxWidth = MaxWidth.Large, BackdropClick = false });

            var result = await dialog.Result;

            if (!result.Canceled)
            {
                await this.InitMeasuresAsync();
            }
        }

        private async Task DeleteMeasureAsync(long ID)
        {
            try
            {
                var response = await this.MeasureHttpRepository.DeleteAsync(ID);
                await this.InitMeasuresAsync();
            }
            catch (Exception ex)
            {
                this.Snackbar.Add("Failed to delete measure. Please try again.", Severity.Error);
                return;
            }
        }
    }
}
