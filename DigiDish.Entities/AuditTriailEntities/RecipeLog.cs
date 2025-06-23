using System.ComponentModel.DataAnnotations.Schema;
using DigiDish.Entities.BaseEntities;
using DigiDish.Entities.Contracts;

namespace DigiDish.Entities.AuditTriailEntities
{
    public class RecipeLog : RecipeBaseEntity, IAuditLog
    {
        public RecipeLog()
        {

        }

        public RecipeLog(Recipe recipe, long userID)
        {
            this.AuditLog = new AuditLog(userID);
            this.UserCreatorID = userID;
            this.LastUserModifiedID = userID;
            this.CreationDate = DateTime.UtcNow;
            this.LastModifiedDate = DateTime.UtcNow;

            this.Name = recipe.Name;
            this.Calories = recipe.Calories;
            this.Description = recipe.Description;
            this.Note = recipe.Note;
        }

        public virtual Recipe Recipe { get; set; }

        [ForeignKey(nameof(Recipe))]
        public virtual long RecipeID { get; set; }

        public virtual AuditLog AuditLog { get; set; }

        public virtual long AuditLogID { get; set; }
    }
}
