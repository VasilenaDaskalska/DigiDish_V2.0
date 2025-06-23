using System.Linq.Expressions;
using DigiDish.BusinessModels.Recipes;
using DigiDish.Entities;

namespace DigiDish.Mappers
{
    public class RecipeMapper
    {
        public static Expression<Func<Recipe, RecipeBiz>> SelectRecipeBizFromRecipeEntity => (recipeEntity) => new RecipeBiz()
        {
            ID = recipeEntity.ID,
            Name = recipeEntity.Name,
            UserCreatorID = recipeEntity.UserCreatorID,
            LastUserModifiedID = recipeEntity.LastUserModifiedID,
            CreationDate = recipeEntity.CreationDate,
            LastModifiedDate = recipeEntity.LastModifiedDate,
            IsDeleted = recipeEntity.IsDeleted,
            Calories = recipeEntity.Calories,
            Description = recipeEntity.Description,
            Note = recipeEntity.Note,
        };

        public static void MapRecipeEntityFromRecipeBiz(ref Recipe recipeEntity, ref RecipeBiz recipeBiz)
        {
            if (recipeBiz is null)
            {
                throw new ArgumentNullException(nameof(recipeBiz));
            }

            recipeEntity.ID = recipeBiz.ID;
            recipeEntity.Name = recipeBiz.Name;
            recipeEntity.UserCreatorID = recipeBiz.UserCreatorID;
            recipeEntity.LastUserModifiedID = recipeBiz.LastUserModifiedID;
            recipeEntity.CreationDate = recipeBiz.CreationDate.UtcDateTime;
            recipeEntity.LastModifiedDate = recipeBiz.LastModifiedDate.UtcDateTime;
            recipeEntity.IsDeleted = recipeBiz.IsDeleted;
            recipeEntity.Calories = recipeBiz.Calories;
            recipeEntity.Description = recipeBiz.Description;
            recipeEntity.Note = recipeBiz.Note;

            if (recipeBiz.RecipeItems != null && recipeBiz.RecipeItems.Count > 0)
            {
                foreach (var recipeItem in recipeBiz.RecipeItems)
                {
                    recipeEntity.RecipeItems.Add(ProductMapper.MapProductEntityFromProductBiz(recipeItem));
                }
            }
        }

        public static void MapRecipeBizFromRecipeEntity(ref RecipeBiz recipeBiz, ref Recipe recipeEntity)
        {
            if (recipeEntity is null)
            {
                throw new ArgumentNullException(nameof(recipeEntity));
            }

            recipeBiz.ID = recipeEntity.ID;
            recipeBiz.Name = recipeEntity.Name;
            recipeBiz.UserCreatorID = recipeEntity.UserCreatorID;
            recipeBiz.LastUserModifiedID = recipeEntity.LastUserModifiedID;
            recipeBiz.CreationDate = recipeEntity.CreationDate;
            recipeBiz.LastModifiedDate = recipeEntity.LastModifiedDate;
            recipeBiz.IsDeleted = recipeEntity.IsDeleted;
            recipeBiz.Calories = recipeEntity.Calories;
            recipeBiz.Note = recipeEntity.Note;
            recipeBiz.Description = recipeEntity.Description;

            if (recipeEntity.RecipeItems != null && recipeEntity.RecipeItems.Count > 0)
            {
                foreach (var recipeItem in recipeEntity.RecipeItems)
                {
                    recipeBiz.RecipeItems.Add(ProductMapper.MapProductBizFromProductEntity(recipeItem));
                }
            }
        }

        public static RecipeBiz MapRecipeBizFromRecipeEntity(Recipe recipeEntity)
        {
            if (recipeEntity is null)
            {
                throw new ArgumentNullException(nameof(recipeEntity));
            }

            RecipeBiz recipeBiz = new RecipeBiz();

            recipeBiz.ID = recipeEntity.ID;
            recipeBiz.Name = recipeEntity.Name;
            recipeBiz.UserCreatorID = recipeEntity.UserCreatorID;
            recipeBiz.LastUserModifiedID = recipeEntity.LastUserModifiedID;
            recipeBiz.CreationDate = recipeEntity.CreationDate;
            recipeBiz.LastModifiedDate = recipeEntity.LastModifiedDate;
            recipeBiz.IsDeleted = recipeEntity.IsDeleted;
            recipeBiz.Calories = recipeEntity.Calories;
            recipeBiz.Note = recipeEntity.Note;
            recipeBiz.Description = recipeEntity.Description;

            if (recipeEntity.RecipeItems != null && recipeEntity.RecipeItems.Count > 0)
            {
                foreach (var recipeItem in recipeEntity.RecipeItems)
                {
                    recipeBiz.RecipeItems.Add(ProductMapper.MapProductBizFromProductEntity(recipeItem));
                }
            }

            return recipeBiz;
        }

        public static Recipe MapRecipeEntityFromRecipeBiz(RecipeBiz recipeBiz)
        {
            if (recipeBiz is null)
            {
                throw new ArgumentNullException(nameof(recipeBiz));
            }

            Recipe recipeEntity = new Recipe();

            recipeEntity.ID = recipeBiz.ID;
            recipeEntity.Name = recipeBiz.Name;
            recipeEntity.UserCreatorID = recipeBiz.UserCreatorID;
            recipeEntity.LastUserModifiedID = recipeBiz.LastUserModifiedID;
            recipeEntity.CreationDate = recipeBiz.CreationDate.UtcDateTime;
            recipeEntity.LastModifiedDate = recipeBiz.LastModifiedDate.UtcDateTime;
            recipeEntity.IsDeleted = recipeBiz.IsDeleted;
            recipeEntity.Calories = recipeBiz.Calories;
            recipeEntity.Note = recipeEntity.Note;
            recipeEntity.Description = recipeBiz.Description;

            if (recipeBiz.RecipeItems != null && recipeBiz.RecipeItems.Count > 0)
            {
                foreach (var recipeItem in recipeBiz.RecipeItems)
                {
                    recipeEntity.RecipeItems.Add(ProductMapper.MapProductEntityFromProductBiz(recipeItem));
                }
            }

            return recipeEntity;
        }
    }
}
