using DigiDish.BusinessModels.BaseBiz;
using DigiDish.BusinessModels.Contracts;

namespace DigiDish.BusinessModels.Products
{
    public class ProductBaseBiz : AuditInfoBiz, IBaseBiz, IDeletableBiz
    {
        public long ID { get; set; }

        public bool IsDeleted { get; set; }

        public string Name { get; set; }

        public long MeasureID { get; set; }

        public string MeasureShortName { get; set; }

        public decimal? Calories { get; set; }

        public decimal? Quantity { get; set; }

        public long? ShoppingListID { get; set; }

        public long? RecipeID { get; set; }
    }
}
