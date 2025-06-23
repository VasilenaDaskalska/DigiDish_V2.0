using DigiDish.BusinessModels.Products;
using DigiDish.HttpRepository.Contracts;
using DigiDish_V2.Client.Shared.Dialogs;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DigiDish_V2.Client.Pages
{
    public partial class ProductsPage : IDisposable
    {
        private ProductBiz selectedProduct;
        private bool isSearching;
        private bool isSelectedProductLoading;
        private bool isLoading;

        [Inject]
        protected IProductHttpRepository ProductHttpRepository { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        [Inject]
        private ISnackbar Snackbar { get; set; }

        public List<ProductBiz> Products { get; set; }

        public void Dispose()
        {

        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await this.InitProductsAsync();
        }

        private async Task InitProductsAsync()
        {
            this.isLoading = true;
            var response = await this.ProductHttpRepository.GetAllAsync();
            this.isLoading = false;
            if (response != null)
            {
                this.Products = response?.ToList() ?? new List<ProductBiz>();
            }

            this.selectedProduct = new ProductBiz();
        }

        private async Task AddOrEditProduct(ProductBiz product)
        {
            var parameters = new DialogParameters { ["Product"] = product };
            var dialog = this.DialogService.Show<AddOrEditProductDialog>(string.Empty, parameters, new DialogOptions { NoHeader = true, MaxWidth = MaxWidth.Large, BackdropClick = false });

            var result = await dialog.Result;

            if (!result.Canceled)
            {
                await this.InitProductsAsync();
            }
        }

        private async Task DeleteProductAsync(long ID)
        {
            try
            {
                var response = await this.ProductHttpRepository.DeleteAsync(ID);
                await this.InitProductsAsync();
            }
            catch (Exception ex)
            {
                this.Snackbar.Add("Failed to delete product. Please try again.", Severity.Error);
                return;
            }
        }
    }
}
