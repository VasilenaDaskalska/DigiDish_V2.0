using DigiDish.BusinessModels.Products;

namespace DigiDish.HttpRepository.Contracts
{
    public interface IProductHttpRepository
    {
        Task<IEnumerable<ProductBiz>> GetAllAsync();

        Task<ProductBiz?> GetByIdAsync(long id);

        Task UpdateAsync(ProductBiz user);

        Task<bool> DeleteAsync(long id);

        Task<ProductBiz> CreateAsync(ProductBiz model);
    }
}
