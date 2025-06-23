using System.ComponentModel.DataAnnotations;
using DigiDish.Entities.Contracts;

namespace DigiDish.Entities.BaseEntities
{
    public abstract class RecipeBaseEntity : BaseEntity, IDeletable, IAuditInfo
    {
        [Required]
        public string Name { get; set; }

        public decimal? Calories { get; set; }

        public string Description { get; set; }

        public string Note { get; set; }

        public bool IsDeleted { get; set; }

        public virtual long UserCreatorID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        public virtual long LastUserModifiedID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LastModifiedDate { get; set; }
    }
}
