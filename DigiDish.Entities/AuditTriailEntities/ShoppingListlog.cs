using System.ComponentModel.DataAnnotations.Schema;
using DigiDish.Entities.BaseEntities;
using DigiDish.Entities.Contracts;

namespace DigiDish.Entities.AuditTriailEntities
{
    public class ShoppingListlog : ShoppingListBaseEntity, IAuditLog
    {
        public ShoppingListlog()
        {

        }

        public ShoppingListlog(ShoppingList shoppingList, long userID)
        {
            this.AuditLog = new AuditLog(userID);
            this.UserCreatorID = userID;
            this.LastUserModifiedID = userID;
            this.CreationDate = DateTime.UtcNow;
            this.LastModifiedDate = DateTime.UtcNow;

            this.Title = shoppingList.Title;
        }

        public virtual ShoppingList ShoppingList { get; set; }

        [ForeignKey(nameof(ShoppingList))]
        public virtual long ShoppingListID { get; set; }

        public virtual AuditLog AuditLog { get; set; }

        public virtual long AuditLogID { get; set; }
    }
}
