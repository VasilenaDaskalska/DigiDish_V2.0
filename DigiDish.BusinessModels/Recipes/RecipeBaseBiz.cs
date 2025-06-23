using DigiDish.BusinessModels.BaseBiz;
using DigiDish.BusinessModels.Contracts;

namespace DigiDish.BusinessModels.Recipes
{
    public class RecipeBaseBiz : AuditInfoBiz, IBaseBiz, IDeletableBiz
    {
        public long ID { get; set; }

        public bool IsDeleted { get; set; }

        public string Name { get; set; }

        public decimal? Calories { get; set; }

        public string Description { get; set; }

        public string Note { get; set; }
    }
}
