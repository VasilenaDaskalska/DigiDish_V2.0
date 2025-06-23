using DigiDish.BusinessModels.ShoppingLists;

namespace DigiDish.Services.Contracts
{
    public interface IShoppingListService
    {
        Task<ShoppingListBiz?> GetByIdAsync(long id);

        Task<IEnumerable<ShoppingListBiz>> GetAllAsync();

        Task<ShoppingListBiz> CreateAsync(ShoppingListBiz model);

        Task<ShoppingListBiz> UpdateAsync(ShoppingListBiz model);

        Task<bool> DeleteAsync(long id);
    }
}
