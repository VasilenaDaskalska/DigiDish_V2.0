using DigiDish.BusinessModels.Products;
using DigiDish.BusinessModels.Recipes;
using DigiDish.HttpRepository.Contracts;
using DigiDish_V2.Client.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DigiDish_V2.Client.Shared.Dialogs
{
    public partial class AddOrEditRecipeDialog
    {
        private MudForm form;
        private bool success;

        [CascadingParameter]
        private IMudDialogInstance MudDialog { get; set; }

        [Parameter]
        public RecipeBiz Recipe { get; set; }

        [Inject]
        private IRecipeHttpRepository RecipeHttpRepository { get; set; }

        [Inject]
        private IProductHttpRepository ProductHttpRepository { get; set; }

        [Inject]
        private UserState UserState { get; set; }

        [Inject]
        private ISnackbar Snackbar { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            this.Recipe.RecipeItems = new List<ProductBiz>();
        }

        private async Task SaveAsync()
        {
            await this.form.Validate();

            if (this.form.IsValid && this.Recipe != null)
            {
                this.Recipe.CreationDate = DateTime.Now;
                this.Recipe.LastModifiedDate = DateTime.Now;
                this.Recipe.LastUserModifiedID = this.UserState.CurrentUser?.ID ?? 0;

                if (this.Recipe.ID > 0)
                {
                    try
                    {
                        await this.RecipeHttpRepository.UpdateAsync(this.Recipe);
                    }
                    catch (Exception ex)
                    {
                        this.Snackbar.Add("Failed to update measure. Please try again.", Severity.Error);
                        return;
                    }

                }
                else
                {
                    this.Recipe.UserCreatorID = this.UserState.CurrentUser?.ID ?? 0;

                    var response = await this.RecipeHttpRepository.CreateAsync(this.Recipe);

                    if (response != null)
                    {
                        this.Recipe = response;
                    }
                    else
                    {
                        this.Snackbar.Add("Failed to add measure. Please try again.", Severity.Error);
                        return;
                    }
                }


                this.MudDialog.Close(DialogResult.Ok(this.Recipe));
            }
        }

        private async Task AddProductToRecipe()
        {
            var selectedProducts = new List<ProductSelectionModel>();
            var dialog = this.DialogService.Show<AddProductsToRecipeDialog>("Select Products");
            var result = await dialog.Result;

            if (!result.Canceled)
            {
                selectedProducts = (List<ProductSelectionModel>)result.Data;
            }

            if (selectedProducts != null && selectedProducts.Count > 0)
            {
                foreach (var product in selectedProducts)
                {
                    var productToAdd = await this.ProductHttpRepository.GetByIdAsync(product.ID);
                    this.Recipe.RecipeItems.Add(productToAdd);
                }
            }
        }

        private async Task CancelAsync()
        {
            this.MudDialog.Cancel();
        }
    }
}
