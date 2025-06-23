using DigiDish.BusinessModels.Products;
using DigiDish.HttpRepository.Contracts;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DigiDish_V2.Client.Shared.Dialogs
{
    public partial class AddProductsToRecipeDialog
    {
        [CascadingParameter]
        private IMudDialogInstance MudDialog { get; set; }

        [Parameter]
        public List<ProductSelectionModel> Products { get; set; } = new();

        public List<ProductBiz> AvailableProducts { get; set; } = new();

        [Inject]
        private IProductHttpRepository ProductHttpRepository { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var dbProducts = await this.ProductHttpRepository.GetAllAsync();
            this.Products = dbProducts.Select(p => new ProductSelectionModel
            {
                ID = p.ID,
                Name = p.Name,
                IsSelected = false
            }).ToList();
        }

        private void Save()
        {
            var selected = this.Products.Where(p => p.IsSelected).ToList();
            this.MudDialog.Close(DialogResult.Ok(selected));
        }

        private void Cancel()
        {
            this.MudDialog.Cancel();
        }

        private async Task AddProductAsync()
        {
            var parameters = new DialogParameters { ["Product"] = new ProductBiz() };
            var dialog = this.DialogService.Show<AddOrEditProductDialog>(string.Empty, parameters, new DialogOptions { NoHeader = true, MaxWidth = MaxWidth.Large, BackdropClick = false });

            var result = await dialog.Result;

            if (!result.Canceled)
            {
                var addedProduct = result.Data as ProductBiz;

                if (addedProduct != null)
                {
                    this.Products.Add(this.MapProductSimpleBizFromProductBiz(addedProduct));
                }
            }
        }

        private ProductSelectionModel MapProductSimpleBizFromProductBiz(ProductBiz product)
        {
            return new ProductSelectionModel
            {
                ID = product.ID,
                Name = product.Name,
                IsSelected = false,
            };
        }
    }
}
