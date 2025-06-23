using DigiDish.BusinessModels.Measures;
using DigiDish.BusinessModels.Products;
using DigiDish.HttpRepository.Contracts;
using DigiDish_V2.Client.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DigiDish_V2.Client.Shared.Dialogs
{
    public partial class AddOrEditProductDialog
    {
        private MudForm form;
        private bool success;

        [CascadingParameter]
        private IMudDialogInstance MudDialog { get; set; }

        [Parameter]
        public ProductBiz Product { get; set; } = new ProductBiz();

        [Inject]
        private IMeasureHttpRepository MeasureHttpRepository { get; set; }

        [Inject]
        private IProductHttpRepository ProductHttpRepository { get; set; }

        [Inject]
        private ISnackbar Snackbar { get; set; }

        [Inject]
        private UserState UserState { get; set; }

        public List<MeasureBiz> Measures { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            this.Measures = (await this.MeasureHttpRepository.GetAllAsync())?.ToList() ?? new List<MeasureBiz>();
        }

        private async Task SaveAsync()
        {
            await this.form.Validate();

            if (this.form.IsValid)
            {
                this.Product.CreationDate = DateTime.Now;
                this.Product.LastModifiedDate = DateTime.Now;
                this.Product.LastUserModifiedID = this.UserState.CurrentUser?.ID ?? 0;
                this.Product.MeasureShortName = this.Measures.FirstOrDefault(m => m.ID == this.Product.MeasureID)?.ShortName ?? string.Empty;
                if (this.Product.ID > 0)
                {
                    try
                    {
                        await this.ProductHttpRepository.UpdateAsync(this.Product);
                    }
                    catch (Exception ex)
                    {
                        this.Snackbar.Add("Failed to update product. Please try again.", Severity.Error);
                        return;
                    }

                }
                else
                {
                    this.Product.UserCreatorID = this.UserState.CurrentUser?.ID ?? 0;
                    var result = await this.ProductHttpRepository.CreateAsync(this.Product);

                    if (result != null)
                    {
                        this.Product = result;
                    }
                    else
                    {
                        this.Snackbar.Add("Failed to add product. Please try again.", Severity.Error);
                        return;
                    }
                }

                this.MudDialog.Close(DialogResult.Ok(this.Product));
            }
        }

        private void CancelAsync()
        {
            this.MudDialog.Cancel();
        }
    }
}