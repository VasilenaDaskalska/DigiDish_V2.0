using DigiDish.BusinessModels.ShoppingLists;
using DigiDish.HttpRepository.Contracts;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DigiDish_V2.Client.Pages
{
    public partial class ShoppingList : IDisposable
    {
        private ShoppingListBiz selectedShoppingList;
        private bool isSearching;
        private bool isSelectedShoppingListLoading;
        private bool isLoading;

        [Inject]
        protected IShoppingListHttpRepository ShoppingListHttpRepository { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        private ISnackbar Snackbar { get; set; }

        public List<ShoppingListBiz> ShoppingLists { get; set; }

        public void Dispose()
        {

        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await this.InitShoppingListsAsync();
        }

        private async Task InitShoppingListsAsync()
        {
            this.isLoading = true;
            var response = await this.ShoppingListHttpRepository.GetAllAsync();
            this.isLoading = false;
            if (response != null)
            {
                this.ShoppingLists = response?.ToList() ?? new List<ShoppingListBiz>();
            }
        }

        private async Task AddOrEditShoppingList(long ID)
        {
            this.NavigationManager.NavigateTo($"/ShoppingList/{ID}");
        }

        private async Task DeleteShoppingAsync(long ID)
        {
            try
            {
                var response = await this.ShoppingListHttpRepository.DeleteAsync(ID);
                await this.InitShoppingListsAsync();
            }
            catch (Exception ex)
            {
                this.Snackbar.Add("Failed to delete product. Please try again.", Severity.Error);
                return;
            }
        }
    }
}
