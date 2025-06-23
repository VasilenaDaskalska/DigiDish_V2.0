using DigiDish.BusinessModels.Products;
using DigiDish.HttpRepository.Contracts;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DigiDish_V2.Client.Shared.Dialogs
{
    public partial class AddOrEditShoppingListItemDialog
    {
        private MudForm form;
        private bool success;

        [CascadingParameter]
        private IMudDialogInstance MudDialog { get; set; }

        [Parameter]
        public ProductBiz ShoppingListItem { get; set; }

        [Inject]
        private IProductHttpRepository ProductHttpRepository { get; set; }

        public List<ProductBiz> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            this.Products = (await this.ProductHttpRepository.GetAllAsync())?.ToList() ?? new List<ProductBiz>();
        }

        private async Task SaveAsync()
        {
            await this.form.Validate();

            if (this.form.IsValid)
            {
                this.MudDialog.Close(DialogResult.Ok(this.ShoppingListItem));
            }
        }

        private async Task CancelAsync()
        {
            this.MudDialog.Cancel();
        }
    }
}
