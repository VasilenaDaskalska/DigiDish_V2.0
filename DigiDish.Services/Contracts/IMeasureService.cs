using DigiDish.BusinessModels.Measures;

namespace DigiDish.Services.Contracts
{
    public interface IMeasureService
    {
        Task<MeasureBiz?> GetByIdAsync(long id);

        Task<IEnumerable<MeasureBiz>> GetAllAsync();

        Task<MeasureBiz> CreateAsync(MeasureBiz model);

        Task<MeasureBiz> UpdateAsync(MeasureBiz model);

        Task<bool> DeleteAsync(long id);
    }
}
