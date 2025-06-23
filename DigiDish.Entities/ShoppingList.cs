using System.ComponentModel.DataAnnotations.Schema;
using DigiDish.Entities.BaseEntities;

namespace DigiDish.Entities
{
    [Table("shopping_list")]
    public class ShoppingList : ShoppingListBaseEntity
    {
        public ShoppingList()
        {
            this.ShoppingListItems = new List<Product>();
        }

        [InverseProperty(nameof(Product.ShoppingList))]
        public virtual ICollection<Product> ShoppingListItems { get; set; }
    }
}
