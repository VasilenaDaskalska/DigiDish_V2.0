using DigiDish.Entities.Context;
using DigiDish.Entities.Contracts;
using DigiDish.HttpRepository.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DigiDish.HttpRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DigiDishDbContext Context;
        protected readonly DbSet<T> DBSet;
        protected readonly ILogger<Repository<T>> Logger;

        public Repository(DigiDishDbContext context, ILogger<Repository<T>> logger)
        {
            this.Context = context;
            this.DBSet = context.Set<T>();
            this.Logger = logger;
        }

        public async Task<T?> GetByIdAsync(long id)
            => await this.DBSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync()
            => await this.DBSet.ToListAsync();

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await this.DBSet.AddAsync(entity);
                await this.Context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException dbEx)
            {
                var msg = dbEx.InnerException?.Message ?? dbEx.Message;
                this.Logger.LogError(dbEx, "Error adding entity of type {EntityType}: {Message}", typeof(T).Name, msg);
                throw new Exception($"Failed to add entity: {msg}");
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                this.Context.Entry(entity).State = EntityState.Modified;
                await this.Context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                var msg = dbEx.InnerException?.Message ?? dbEx.Message;
                this.Logger.LogError(dbEx, "Error updating entity of type {EntityType}: {Message}", typeof(T).Name, msg);
                throw new Exception($"Failed to update entity: {msg}");
            }
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await this.DBSet.FindAsync(id);
            if (entity == null) return;

            try
            {
                if (entity is IDeletable deletableEntity)
                {
                    deletableEntity.IsDeleted = true;
                    this.Context.Entry(deletableEntity).State = EntityState.Modified;
                }
                else
                {
                    this.DBSet.Remove(entity);
                }

                await this.Context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                var msg = dbEx.InnerException?.Message ?? dbEx.Message;
                this.Logger.LogError(dbEx, "Error deleting entity of type {EntityType}: {Message}", typeof(T).Name, msg);
                throw new Exception($"Failed to delete entity: {msg}");
            }
        }
    }
}
