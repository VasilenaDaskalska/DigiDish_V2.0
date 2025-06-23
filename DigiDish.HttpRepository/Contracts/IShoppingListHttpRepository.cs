using DigiDish.BusinessModels.ShoppingLists;

namespace DigiDish.HttpRepository.Contracts
{
    public interface IShoppingListHttpRepository
    {
        Task<IEnumerable<ShoppingListBiz>> GetAllAsync();

        Task<ShoppingListBiz> GetByIdAsync(long id);

        Task UpdateAsync(ShoppingListBiz shoppingList);

        Task<bool> DeleteAsync(long id);

        Task<ShoppingListBiz> CreateAsync(ShoppingListBiz model);
    }
}
