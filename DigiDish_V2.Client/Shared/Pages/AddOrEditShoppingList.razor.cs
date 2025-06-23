using DigiDish.BusinessModels.Products;
using DigiDish.BusinessModels.ShoppingLists;
using DigiDish.HttpRepository.Contracts;
using DigiDish_V2.Client.Services;
using DigiDish_V2.Client.Shared.Dialogs;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DigiDish_V2.Client.Shared.Pages
{
    public partial class AddOrEditShoppingList
    {
        private bool isLoading;

        [Parameter]
        public long ShoppingListId { get; set; }

        public ShoppingListBiz ShoppingList { get; set; }

        public ProductBiz ShoppingListItem { get; set; }


        [Inject]
        private ISnackbar Snackbar { get; set; }

        [Inject]
        private IShoppingListHttpRepository ShoppingListHttpRepository { get; set; }

        [Inject]
        private IProductHttpRepository ProductHttpRepository { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        [Inject]
        private UserState UserState { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await this.LoadShoppingListAsync();
        }

        private async Task LoadShoppingListAsync()
        {
            if (this.ShoppingListId == 0)
            {
                this.ShoppingList = new ShoppingListBiz();
                this.ShoppingList.ShoppingListItems = new List<ProductBiz>();
            }
            else
            {
                this.isLoading = true;
                var response = await this.ShoppingListHttpRepository.GetByIdAsync(this.ShoppingListId);
                this.isLoading = false;
                if (response == null)
                {
                    this.Snackbar.Add("Cannot find shopping list!", Severity.Error);
                    return;
                }
                else
                {
                    this.ShoppingList = response;
                }
            }

            this.ShoppingListItem = new ProductBiz();
        }

        private async Task AddOrEditItemAsync()
        {
            var parameters = new DialogParameters { ["ShoppingListItem"] = this.ShoppingListItem };
            var dialog = this.DialogService.Show<AddOrEditShoppingListItemDialog>(string.Empty, parameters);

            var result = await dialog.Result;

            if (!result.Canceled)
            {
                this.ShoppingListItem = result.Data as ProductBiz;
                var product = await this.ProductHttpRepository.GetByIdAsync(this.ShoppingListItem.ID);
                this.ShoppingList.ShoppingListItems.Add(product);
                await this.InvokeAsync(this.StateHasChanged);
            }
        }

        private void EditItem(ProductBiz item)
        {
            // Open dialog or inline edit logic here
            this.Snackbar.Add($"Edit item: {item.Name}", Severity.Info);
        }

        private async Task SaveShoppingList()
        {
            if (this.ShoppingList != null)
            {
                this.ShoppingList.CreationDate = DateTime.Now;
                this.ShoppingList.LastModifiedDate = DateTime.Now;
                this.ShoppingList.LastUserModifiedID = this.UserState.CurrentUser?.ID ?? 0;

                if (this.ShoppingList.ID > 0)
                {
                    try
                    {
                        await this.ShoppingListHttpRepository.UpdateAsync(this.ShoppingList);
                    }
                    catch (Exception ex)
                    {
                        this.Snackbar.Add("Failed to update measure. Please try again.", Severity.Error);
                        return;
                    }

                }
                else
                {
                    this.ShoppingList.UserCreatorID = this.UserState.CurrentUser?.ID ?? 0;

                    var response = await this.ShoppingListHttpRepository.CreateAsync(this.ShoppingList);

                    if (response != null)
                    {
                        this.ShoppingList = response;
                    }
                    else
                    {
                        this.Snackbar.Add("Failed to add measure. Please try again.", Severity.Error);
                        return;
                    }
                }

                this.NavigationManager.NavigateTo("/ShoppingLists");
            }
        }
    }
}
