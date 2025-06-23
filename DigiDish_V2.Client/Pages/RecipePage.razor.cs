using DigiDish.BusinessModels.Recipes;
using DigiDish.HttpRepository.Contracts;
using DigiDish_V2.Client.Shared.Dialogs;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DigiDish_V2.Client.Pages
{
    public partial class RecipePage : IDisposable
    {
        private RecipeBiz selectedRecipe;
        private bool isSearching;
        private bool isSelectedRecipeLoading;
        private bool isLoading;

        [Inject]
        protected IRecipeHttpRepository RecipeHttpRepository { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        [Inject]
        private ISnackbar Snackbar { get; set; }

        public List<RecipeBiz> Recipes { get; set; }

        public void Dispose()
        {

        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await this.InitRecipesAsync();
        }

        private async Task InitRecipesAsync()
        {
            this.isLoading = true;
            var response = await this.RecipeHttpRepository.GetAllAsync();
            this.isLoading = false;
            if (response != null)
            {
                this.Recipes = response?.ToList() ?? new List<RecipeBiz>();
            }

            this.selectedRecipe = new RecipeBiz();
        }

        private async Task AddOrEditRecipe(RecipeBiz recipe)
        {
            var parameters = new DialogParameters { ["Recipe"] = recipe };
            var dialog = this.DialogService.Show<AddOrEditRecipeDialog>(string.Empty, parameters, new DialogOptions { NoHeader = true, MaxWidth = MaxWidth.Large, BackdropClick = false });

            var result = await dialog.Result;

            if (!result.Canceled)
            {
                await this.InitRecipesAsync();
            }
        }

        private async Task DeleteRecipeAsync(long ID)
        {
            try
            {
                var response = await this.RecipeHttpRepository.DeleteAsync(ID);
                await this.InitRecipesAsync();
            }
            catch (Exception ex)
            {
                this.Snackbar.Add("Failed to delete product. Please try again.", Severity.Error);
                return;
            }
        }
    }
}
