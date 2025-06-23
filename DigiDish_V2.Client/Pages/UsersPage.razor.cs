using DigiDish.BusinessModels.Users;
using DigiDish.HttpRepository.Contracts;
using DigiDish_V2.Client.Services;
using Microsoft.AspNetCore.Components;

namespace DigiDish_V2.Client.Pages
{
    public partial class UsersPage
    {
        private bool isLoading;
        private bool isSearching;
        public UserBiz SelectedUser { get; set; }
        public List<UserBiz> Users { get; set; }

        [Inject]
        private IUserHttpRepository UserHttpRepository { get; set; }

        [Inject]
        private UserState UserState { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await this.InitUserAsync();
        }

        private async Task InitUserAsync()
        {
            this.isLoading = true;
            this.Users = (await this.UserHttpRepository.GetAllAsync())?.ToList() ?? new List<UserBiz>();
            this.isLoading = false;
        }
    }
}
