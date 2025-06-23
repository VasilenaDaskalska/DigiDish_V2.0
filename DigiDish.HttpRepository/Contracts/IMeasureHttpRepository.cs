using DigiDish.BusinessModels.Measures;

namespace DigiDish.HttpRepository.Contracts
{
    public interface IMeasureHttpRepository
    {
        Task<IEnumerable<MeasureBiz>> GetAllAsync();

        Task<MeasureBiz> GetByIdAsync(long id);

        Task UpdateAsync(MeasureBiz user);

        Task<bool> DeleteAsync(long id);

        Task<MeasureBiz> CreateAsync(MeasureBiz model);
    }
}
