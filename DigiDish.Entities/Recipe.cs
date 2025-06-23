using System.ComponentModel.DataAnnotations.Schema;
using DigiDish.Entities.BaseEntities;

namespace DigiDish.Entities
{
    public class Recipe : RecipeBaseEntity
    {
        public Recipe()
        {
            this.RecipeItems = new List<Product>();
        }

        [InverseProperty(nameof(Product.Recipe))]
        public virtual ICollection<Product> RecipeItems { get; set; }
    }
}
