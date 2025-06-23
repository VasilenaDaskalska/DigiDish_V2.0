using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigiDish.Entities.Contracts;

namespace DigiDish.Entities.BaseEntities
{
    public abstract class ProductBaseEntity : BaseEntity, IDeletable, IAuditInfo
    {
        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(Measure))]
        public long MeasureID { get; set; }

        public virtual Measure Measure { get; set; }

        [DefaultValue(0.0)]
        public decimal? Calories { get; set; }

        [DefaultValue(0.0)]
        public decimal? Quantity { get; set; }

        [ForeignKey(nameof(ShoppingList))]
        public long? ShoppingListID { get; set; }

        public ShoppingList ShoppingList { get; set; }

        [ForeignKey(nameof(Recipe))]
        public long? RecipeID { get; set; }

        public Recipe Recipe { get; set; }

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
