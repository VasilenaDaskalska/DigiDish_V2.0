using System.ComponentModel;

namespace DigiDish.Entities.Contracts
{
    public interface IDeletable
    {

        [DefaultValue(false)]
        bool IsDeleted { get; set; }
    }
}
