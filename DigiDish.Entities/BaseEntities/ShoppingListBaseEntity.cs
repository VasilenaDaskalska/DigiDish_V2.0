using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DigiDish.Entities.Contracts;

namespace DigiDish.Entities.BaseEntities
{
    public abstract class ShoppingListBaseEntity : BaseEntity, IDeletable, IAuditInfo
    {
        [Required]
        public string Title { get; set; }

        [DefaultValue(false)]
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
