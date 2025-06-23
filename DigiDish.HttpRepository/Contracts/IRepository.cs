namespace DigiDish.HttpRepository.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(long id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        // Soft delete 
        Task DeleteAsync(long id);
    }
}
