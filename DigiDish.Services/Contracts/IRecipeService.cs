using DigiDish.BusinessModels.Recipes;

namespace DigiDish.Services.Contracts
{
    public interface IRecipeService
    {
        Task<RecipeBiz?> GetByIdAsync(long id);

        Task<IEnumerable<RecipeBiz>> GetAllAsync();

        Task<RecipeBiz> CreateAsync(RecipeBiz model);

        Task<RecipeBiz> UpdateAsync(RecipeBiz model);

        Task<bool> DeleteAsync(long id);
    }
}
