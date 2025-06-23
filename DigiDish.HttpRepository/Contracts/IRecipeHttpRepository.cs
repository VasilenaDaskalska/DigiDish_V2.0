using DigiDish.BusinessModels.Recipes;

namespace DigiDish.HttpRepository.Contracts
{
    public interface IRecipeHttpRepository
    {
        Task<IEnumerable<RecipeBiz>> GetAllAsync();

        Task<RecipeBiz> GetByIdAsync(long id);

        Task<RecipeBiz> CreateAsync(RecipeBiz model);

        Task UpdateAsync(RecipeBiz user);

        Task<bool> DeleteAsync(long id);
    }
}
