using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigiDish.Entities.AuditTriailEntities;

namespace DigiDish.Entities.Contracts
{
    public interface IAuditLog : IAuditInfo
    {
        AuditLog AuditLog { get; set; }

        [Required]
        [ForeignKey(nameof(AuditLog))]
        long AuditLogID { get; set; }
    }
}
