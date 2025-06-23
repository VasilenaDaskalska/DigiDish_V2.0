using System.ComponentModel.DataAnnotations;

namespace DigiDish.Entities.BaseEntities
{
    public abstract class BaseEntity
    {
        [Key]
        public long ID { get; set; }
    }
}
