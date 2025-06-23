using System.ComponentModel.DataAnnotations.Schema;
using DigiDish.Entities.BaseEntities;

namespace DigiDish.Entities.AuditTriailEntities
{
    [Table("log_audit_logs")]
    public class AuditLog : AuditInfo
    {
        public AuditLog()
        {
        }

        public AuditLog(long userID)
        {
            this.CreationDate = DateTime.UtcNow;
            this.LastModifiedDate = DateTime.UtcNow;
            this.UserCreatorID = userID;
            this.LastUserModifiedID = userID;
        }
    }
}
