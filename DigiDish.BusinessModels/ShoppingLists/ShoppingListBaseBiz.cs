using DigiDish.BusinessModels.BaseBiz;
using DigiDish.BusinessModels.Contracts;

namespace DigiDish.BusinessModels.ShoppingLists
{
    public class ShoppingListBaseBiz : AuditInfoBiz, IBaseBiz, IDeletableBiz
    {
        public long ID { get; set; }

        public bool IsDeleted { get; set; }

        public string Title { get; set; }
    }
}
