using System.Linq.Expressions;
using DigiDish.BusinessModels.ShoppingLists;
using DigiDish.Entities;

namespace DigiDish.Mappers
{
    public class ShoppingListMapper
    {
        public static Expression<Func<ShoppingList, ShoppingListBiz>> SelectShoppingListBizFromShoppingListEntity => (shoppingListEntity) => new ShoppingListBiz()
        {
            ID = shoppingListEntity.ID,
            Title = shoppingListEntity.Title,
            UserCreatorID = shoppingListEntity.UserCreatorID,
            LastUserModifiedID = shoppingListEntity.LastUserModifiedID,
            CreationDate = shoppingListEntity.CreationDate,
            LastModifiedDate = shoppingListEntity.LastModifiedDate,
            IsDeleted = shoppingListEntity.IsDeleted,
        };

        public static void MapShoppingListEntityFromShoppingListBiz(ref ShoppingList shoppingListEntity, ref ShoppingListBiz shoppingListBiz)
        {
            if (shoppingListBiz is null)
            {
                throw new ArgumentNullException(nameof(shoppingListBiz));
            }

            shoppingListEntity.ID = shoppingListBiz.ID;
            shoppingListEntity.Title = shoppingListBiz.Title;
            shoppingListEntity.UserCreatorID = shoppingListBiz.UserCreatorID;
            shoppingListEntity.LastUserModifiedID = shoppingListBiz.LastUserModifiedID;
            shoppingListEntity.CreationDate = shoppingListBiz.CreationDate.UtcDateTime;
            shoppingListEntity.LastModifiedDate = shoppingListBiz.LastModifiedDate.UtcDateTime;
            shoppingListEntity.IsDeleted = shoppingListBiz.IsDeleted;

            if (shoppingListBiz.ShoppingListItems != null && shoppingListBiz.ShoppingListItems.Count > 0)
            {
                foreach (var recipeItem in shoppingListBiz.ShoppingListItems)
                {
                    shoppingListEntity.ShoppingListItems.Add(ProductMapper.MapProductEntityFromProductBiz(recipeItem));
                }
            }
        }

        public static void MapShoppingListBizFromShoppingListEntity(ref ShoppingListBiz shoppingListBiz, ref ShoppingList shoppingListEntity)
        {
            if (shoppingListBiz is null)
            {
                throw new ArgumentNullException(nameof(shoppingListEntity));
            }

            shoppingListBiz.ID = shoppingListEntity.ID;
            shoppingListBiz.UserCreatorID = shoppingListEntity.UserCreatorID;
            shoppingListBiz.LastUserModifiedID = shoppingListEntity.LastUserModifiedID;
            shoppingListBiz.CreationDate = shoppingListEntity.CreationDate;
            shoppingListBiz.LastModifiedDate = shoppingListEntity.LastModifiedDate;
            shoppingListBiz.IsDeleted = shoppingListEntity.IsDeleted;

            if (shoppingListEntity.ShoppingListItems != null && shoppingListEntity.ShoppingListItems.Count > 0)
            {
                foreach (var recipeItem in shoppingListEntity.ShoppingListItems)
                {
                    shoppingListBiz.ShoppingListItems.Add(ProductMapper.MapProductBizFromProductEntity(recipeItem));
                }
            }
        }

        public static ShoppingListBiz MapShoppingListBizFromShoppingListEntity(ShoppingList shoppingListEntity)
        {
            if (shoppingListEntity is null)
            {
                throw new ArgumentNullException(nameof(shoppingListEntity));
            }

            ShoppingListBiz shoppingListBiz = new ShoppingListBiz();

            shoppingListBiz.ID = shoppingListEntity.ID;
            shoppingListBiz.Title = shoppingListEntity.Title;
            shoppingListBiz.UserCreatorID = shoppingListEntity.UserCreatorID;
            shoppingListBiz.LastUserModifiedID = shoppingListEntity.LastUserModifiedID;
            shoppingListBiz.CreationDate = shoppingListEntity.CreationDate;
            shoppingListBiz.LastModifiedDate = shoppingListEntity.LastModifiedDate;
            shoppingListBiz.IsDeleted = shoppingListEntity.IsDeleted;

            if (shoppingListEntity.ShoppingListItems != null && shoppingListEntity.ShoppingListItems.Count > 0)
            {
                foreach (var recipeItem in shoppingListEntity.ShoppingListItems)
                {
                    shoppingListBiz.ShoppingListItems.Add(ProductMapper.MapProductBizFromProductEntity(recipeItem));
                }
            }

            return shoppingListBiz;
        }

        public static ShoppingList MapShoppingListEntityFromShoppingListBiz(ShoppingListBiz shoppingListBiz)
        {
            if (shoppingListBiz is null)
            {
                throw new ArgumentNullException(nameof(shoppingListBiz));
            }

            ShoppingList shoppingListEntity = new ShoppingList();

            shoppingListEntity.ID = shoppingListBiz.ID;
            shoppingListEntity.Title = shoppingListBiz.Title;
            shoppingListEntity.UserCreatorID = shoppingListBiz.UserCreatorID;
            shoppingListEntity.LastUserModifiedID = shoppingListBiz.LastUserModifiedID;
            shoppingListEntity.CreationDate = shoppingListBiz.CreationDate.UtcDateTime;
            shoppingListEntity.LastModifiedDate = shoppingListBiz.LastModifiedDate.UtcDateTime;
            shoppingListEntity.IsDeleted = shoppingListBiz.IsDeleted;

            if (shoppingListBiz.ShoppingListItems != null && shoppingListBiz.ShoppingListItems.Count > 0)
            {
                foreach (var recipeItem in shoppingListBiz.ShoppingListItems)
                {
                    shoppingListEntity.ShoppingListItems.Add(ProductMapper.MapProductEntityFromProductBiz(recipeItem));
                }
            }

            return shoppingListEntity;
        }
    }
}
