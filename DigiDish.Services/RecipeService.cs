using DigiDish.BusinessModels.Recipes;
using DigiDish.Entities;
using DigiDish.Entities.AuditTriailEntities;
using DigiDish.HttpRepository.Contracts;
using DigiDish.Mappers;
using DigiDish.Services.Contracts;

namespace DigiDish.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository<Recipe> recipeRepository;
        private readonly IRepository<RecipeLog> recipeLogRepository;
        private readonly IRepository<AuditLog> auditLogRepository;

        public RecipeService(
            IRepository<Recipe> recipeRepo,
            IRepository<RecipeLog> recipeLogRepo,
            IRepository<AuditLog> auditLogRepo)
        {
            this.recipeRepository = recipeRepo;
            this.recipeLogRepository = recipeLogRepo;
            this.auditLogRepository = auditLogRepo;
        }

        public async Task<RecipeBiz?> GetByIdAsync(long id)
        {
            try
            {
                var recipe = await this.recipeRepository.GetByIdAsync(id);
                return (recipe == null || recipe.IsDeleted)
                    ? null
                    : RecipeMapper.MapRecipeBizFromRecipeEntity(recipe);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get recipe {ex.Message}");
            }

        }

        public async Task<IEnumerable<RecipeBiz>> GetAllAsync()
        {
            try
            {
                var recipes = await this.recipeRepository.GetAllAsync();
                return recipes
                    .Where(p => !p.IsDeleted)
                    .Select(RecipeMapper.MapRecipeBizFromRecipeEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get recipe {ex.Message}");
            }
        }

        public async Task<RecipeBiz> CreateAsync(RecipeBiz model)
        {
            try
            {
                var entity = RecipeMapper.MapRecipeEntityFromRecipeBiz(model);
                var created = await this.recipeRepository.AddAsync(entity);

                await this.LogChange(created, model.UserCreatorID);
                return RecipeMapper.MapRecipeBizFromRecipeEntity(created);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create recipe {ex.Message}");
            }

        }

        public async Task<RecipeBiz> UpdateAsync(RecipeBiz model)
        {
            try
            {
                var existing = await this.recipeRepository.GetByIdAsync(model.ID);

                if (existing == null || existing.IsDeleted)
                {
                    throw new Exception("Recipe not found.");
                }

                RecipeMapper.MapRecipeEntityFromRecipeBiz(ref existing, ref model);
                await this.recipeRepository.UpdateAsync(existing);
                await this.LogChange(existing, model.LastUserModifiedID);

                return await this.GetByIdAsync(model.ID);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update recipe {ex.Message}");
            }

        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var entity = await this.recipeRepository.GetByIdAsync(id);
                long userId = 19;

                if (entity == null || entity.IsDeleted)
                {
                    throw new Exception("Recipe not found.");
                }

                entity.IsDeleted = true;
                entity.LastModifiedDate = DateTime.UtcNow;
                entity.LastUserModifiedID = userId;

                await this.recipeRepository.UpdateAsync(entity);
                await this.LogChange(entity, userId);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete recipe {ex.Message}");
            }
        }

        private async Task LogChange(Recipe recipe, long userId)
        {
            var auditLog = new AuditLog(userId)
            {
                CreationDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow
            };

            var createdAuditLog = await this.auditLogRepository.AddAsync(auditLog);
            var productLog = new RecipeLog(recipe, userId)
            {
                AuditLogID = createdAuditLog.ID,
                RecipeID = recipe.ID,
            };

            await this.recipeLogRepository.AddAsync(productLog);
        }
    }
}
