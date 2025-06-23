using DigiDish.Entities;

namespace DigiDish_V2.Client.Pages
{
    public partial class DashBoard
    {
        private User? CurrentUser { get; set; }

        protected override void OnInitialized()
        {
            if (!this.UserState.IsAuthenticated)
            {
                this.NavigationManager.NavigateTo("/SignIn");
            }
        }

        private void OpenProducts()
        {
            this.NavigationManager.NavigateTo("/Products");
        }

        private void OpenMeasures()
        {
            this.NavigationManager.NavigateTo("/Measures");
        }


        private void OpenRecipes()
        {
            this.NavigationManager.NavigateTo("/Recipes");
        }

        private void OpenShoppingList()
        {
            this.NavigationManager.NavigateTo("/ShoppingLists");
        }

        private void OpenProfile()
        {
            this.NavigationManager.NavigateTo("/Profile");
        }

        private void OpenUsers()
        {
            this.NavigationManager.NavigateTo("/Users");
        }
    }
}
