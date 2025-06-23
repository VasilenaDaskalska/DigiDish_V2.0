using DigiDish.BusinessModels.BaseBiz;
using DigiDish.BusinessModels.Contracts;

namespace DigiDish.BusinessModels.Measures
{
    public class MeasureBaseBiz : AuditInfoBiz, IBaseBiz, IDeletableBiz
    {
        public long ID { get; set; }

        public bool IsDeleted { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

    }
}
