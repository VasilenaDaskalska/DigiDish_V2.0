using DigiDish.BusinessModels.Products;

namespace DigiDish.BusinessModels.ShoppingLists
{
    public class ShoppingListBiz : ShoppingListBaseBiz
    {
        public ICollection<ProductBiz> ShoppingListItems { get; set; }
    }
}
