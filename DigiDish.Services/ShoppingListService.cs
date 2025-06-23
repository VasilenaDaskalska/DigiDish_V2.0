using DigiDish.BusinessModels.ShoppingLists;
using DigiDish.Entities;
using DigiDish.Entities.AuditTriailEntities;
using DigiDish.HttpRepository.Contracts;
using DigiDish.Mappers;
using DigiDish.Services.Contracts;

namespace DigiDish.Services
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly IRepository<ShoppingList> shoppingListRepository;
        private readonly IRepository<ShoppingListlog> shoppingListLogRepository;
        private readonly IRepository<AuditLog> auditLogRepository;

        public ShoppingListService(
            IRepository<ShoppingList> shoppingListServiceRepo,
            IRepository<ShoppingListlog> shoppingListServiceLogRepo,
            IRepository<AuditLog> auditLogRepo)
        {
            this.shoppingListRepository = shoppingListServiceRepo;
            this.shoppingListLogRepository = shoppingListServiceLogRepo;
            this.auditLogRepository = auditLogRepo;
        }

        public async Task<ShoppingListBiz?> GetByIdAsync(long id)
        {
            try
            {
                var shoppingList = await this.shoppingListRepository.GetByIdAsync(id);
                return (shoppingList == null || shoppingList.IsDeleted)
                    ? null
                    : ShoppingListMapper.MapShoppingListBizFromShoppingListEntity(shoppingList);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get shopping list {ex.Message}");
            }

        }

        public async Task<IEnumerable<ShoppingListBiz>> GetAllAsync()
        {
            try
            {
                var shoppingLists = await this.shoppingListRepository.GetAllAsync();
                return shoppingLists
                    .Where(p => !p.IsDeleted)
                    .Select(ShoppingListMapper.MapShoppingListBizFromShoppingListEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get shopping list {ex.Message}");
            }
        }

        public async Task<ShoppingListBiz> CreateAsync(ShoppingListBiz model)
        {
            try
            {
                var entity = ShoppingListMapper.MapShoppingListEntityFromShoppingListBiz(model);
                var created = await this.shoppingListRepository.AddAsync(entity);

                await this.LogChange(created, model.UserCreatorID);
                return ShoppingListMapper.MapShoppingListBizFromShoppingListEntity(created);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get shopping list {ex.Message}");
            }

        }

        public async Task<ShoppingListBiz> UpdateAsync(ShoppingListBiz model)
        {
            try
            {
                var existing = await this.shoppingListRepository.GetByIdAsync(model.ID);

                if (existing == null || existing.IsDeleted)
                {
                    throw new Exception("Shopping list not found.");
                }

                ShoppingListMapper.MapShoppingListEntityFromShoppingListBiz(ref existing, ref model);
                await this.shoppingListRepository.UpdateAsync(existing);
                await this.LogChange(existing, model.LastUserModifiedID);

                return await this.GetByIdAsync(model.ID);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update shopping list {ex.Message}");
            }

        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var entity = await this.shoppingListRepository.GetByIdAsync(id);
                long userId = 19;

                if (entity == null || entity.IsDeleted)
                {
                    throw new Exception("Shopping list not found.");
                }

                entity.IsDeleted = true;
                entity.LastModifiedDate = DateTime.UtcNow;
                entity.LastUserModifiedID = userId;

                await this.shoppingListRepository.UpdateAsync(entity);
                await this.LogChange(entity, userId);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete shopping list {ex.Message}");
            }
        }

        private async Task LogChange(ShoppingList shoppingList, long userId)
        {
            var auditLog = new AuditLog(userId)
            {
                CreationDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow
            };

            var createdAuditLog = await this.auditLogRepository.AddAsync(auditLog);
            var productLog = new ShoppingListlog(shoppingList, userId)
            {
                AuditLogID = createdAuditLog.ID,
                ShoppingListID = shoppingList.ID,
            };

            await this.shoppingListLogRepository.AddAsync(productLog);
        }
    }
}
