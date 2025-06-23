using System.ComponentModel.DataAnnotations.Schema;
using DigiDish.Entities.BaseEntities;

namespace DigiDish.Entities
{
    [Table("users")]
    public class User : UserBaseEntity
    {
    }
}
