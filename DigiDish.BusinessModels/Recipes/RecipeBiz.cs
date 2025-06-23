using DigiDish.BusinessModels.Products;

namespace DigiDish.BusinessModels.Recipes
{
    public class RecipeBiz : RecipeBaseBiz
    {
        public ICollection<ProductBiz> RecipeItems { get; set; }
    }
}
