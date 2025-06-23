using DigiDish.BusinessModels.Products;

namespace DigiDish.Services.Contracts
{
    public interface IProductService
    {
        Task<ProductBiz?> GetByIdAsync(long id);

        Task<IEnumerable<ProductBiz>> GetAllAsync();

        Task<ProductBiz> CreateAsync(ProductBiz model);

        Task<ProductBiz> UpdateAsync(ProductBiz model);

        Task<bool> DeleteAsync(long id);
    }
}
