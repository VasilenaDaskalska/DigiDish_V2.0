using System.Linq.Expressions;
using DigiDish.BusinessModels.Products;
using DigiDish.Entities;

namespace DigiDish.Mappers
{
    public class ProductMapper
    {
        public static Expression<Func<Product, ProductBiz>> SelectProductBizFromProductEntity => (productEntity) => new ProductBiz()
        {
            ID = productEntity.ID,
            Name = productEntity.Name,
            UserCreatorID = productEntity.UserCreatorID,
            LastUserModifiedID = productEntity.LastUserModifiedID,
            CreationDate = productEntity.CreationDate,
            LastModifiedDate = productEntity.LastModifiedDate,
            IsDeleted = productEntity.IsDeleted,
            Calories = productEntity.Calories,
            MeasureID = productEntity.MeasureID,
            MeasureShortName = productEntity.Measure != null ? productEntity.Measure.ShortName : string.Empty,
            Quantity = productEntity.Quantity,
            RecipeID = productEntity.RecipeID,
            ShoppingListID = productEntity.ShoppingListID,
        };

        public static void MapProductEntityFromProductBiz(ref Product productEntity, ref ProductBiz productBiz)
        {
            productEntity.ID = productBiz.ID;
            productEntity.Name = productBiz.Name;
            productEntity.UserCreatorID = productBiz.UserCreatorID;
            productEntity.LastUserModifiedID = productBiz.LastUserModifiedID;
            productEntity.CreationDate = productBiz.CreationDate.UtcDateTime;
            productEntity.LastModifiedDate = productBiz.LastModifiedDate.UtcDateTime;
            productEntity.IsDeleted = productBiz.IsDeleted;
            productEntity.Calories = productBiz.Calories;
            productEntity.Quantity = productBiz.Quantity;
            productEntity.RecipeID = productBiz.RecipeID;
            productEntity.ShoppingListID = productBiz.ShoppingListID;
            productEntity.MeasureID = productBiz.MeasureID;
        }

        public static Product MapProductEntityFromProductBiz(ProductBiz productBiz)
        {
            return new Product()
            {
                ID = productBiz.ID,
                Name = productBiz.Name,
                UserCreatorID = productBiz.UserCreatorID,
                LastUserModifiedID = productBiz.LastUserModifiedID,
                CreationDate = productBiz.CreationDate.UtcDateTime,
                LastModifiedDate = productBiz.LastModifiedDate.UtcDateTime,
                IsDeleted = productBiz.IsDeleted,
                Calories = productBiz.Calories,
                Quantity = productBiz.Quantity,
                RecipeID = productBiz.RecipeID,
                ShoppingListID = productBiz.ShoppingListID,
                MeasureID = productBiz.MeasureID,
            };
        }

        public static ProductBiz MapProductBizFromProductEntity(Product productEntity)
        {
            return new ProductBiz()
            {
                ID = productEntity.ID,
                Name = productEntity.Name,
                UserCreatorID = productEntity.UserCreatorID,
                LastUserModifiedID = productEntity.LastUserModifiedID,
                CreationDate = productEntity.CreationDate,
                LastModifiedDate = productEntity.LastModifiedDate,
                IsDeleted = productEntity.IsDeleted,
                Calories = productEntity.Calories,
                Quantity = productEntity.Quantity,
                RecipeID = productEntity.RecipeID,
                ShoppingListID = productEntity.ShoppingListID,
                MeasureID = productEntity.MeasureID,
                MeasureShortName = productEntity.Measure != null ? productEntity.Measure.ShortName : string.Empty,
            };
        }

        public static void MapProductBizFromProductEntity(ref ProductBiz productBiz, ref Product productEntity)
        {
            productBiz.ID = productEntity.ID;
            productBiz.Name = productEntity.Name;
            productBiz.UserCreatorID = productEntity.UserCreatorID;
            productBiz.LastUserModifiedID = productEntity.LastUserModifiedID;
            productBiz.CreationDate = productEntity.CreationDate;
            productBiz.LastModifiedDate = productEntity.LastModifiedDate;
            productBiz.IsDeleted = productEntity.IsDeleted;
            productBiz.Calories = productEntity.Calories;
            productBiz.Quantity = productEntity.Quantity;
            productBiz.RecipeID = productEntity.RecipeID;
            productBiz.ShoppingListID = productEntity.ShoppingListID;
            productBiz.MeasureID = productEntity.MeasureID;
            productBiz.MeasureShortName = productEntity.Measure != null ? productEntity.Measure.ShortName : string.Empty;
        }
    }
}
