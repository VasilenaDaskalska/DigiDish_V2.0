using System.ComponentModel.DataAnnotations.Schema;
using DigiDish.Entities.BaseEntities;
using DigiDish.Entities.Contracts;

namespace DigiDish.Entities.AuditTriailEntities
{
    public class ProductLog : ProductBaseEntity, IAuditLog
    {
        public ProductLog()
        {

        }

        public ProductLog(Product product, long userID)
        {
            this.AuditLog = new AuditLog(userID);
            this.UserCreatorID = userID;
            this.LastUserModifiedID = userID;
            this.CreationDate = DateTime.UtcNow;
            this.LastModifiedDate = DateTime.UtcNow;

            this.Name = product.Name;
            this.Measure = product.Measure;
            this.MeasureID = product.MeasureID;
            this.Calories = product.Calories;
            this.ShoppingList = product.ShoppingList;
            this.ShoppingListID = product.ShoppingListID;
            this.Recipe = product.Recipe;
            this.RecipeID = product.RecipeID;
            this.Quantity = product.Quantity;
        }


        public virtual Product Product { get; set; }

        [ForeignKey(nameof(Product))]
        public virtual long ProductID { get; set; }

        public virtual AuditLog AuditLog { get; set; }

        public virtual long AuditLogID { get; set; }
    }
}
