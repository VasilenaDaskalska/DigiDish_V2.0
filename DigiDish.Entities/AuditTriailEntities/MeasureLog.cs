using System.ComponentModel.DataAnnotations.Schema;
using DigiDish.Entities.BaseEntities;
using DigiDish.Entities.Contracts;

namespace DigiDish.Entities.AuditTriailEntities
{
    public class MeasureLog : MeasureBaseEntity, IAuditLog
    {
        public MeasureLog()
        {

        }

        public MeasureLog(Measure measure, long userID)
        {
            this.AuditLog = new AuditLog(userID);
            this.UserCreatorID = userID;
            this.LastUserModifiedID = userID;
            this.CreationDate = DateTime.UtcNow;
            this.LastModifiedDate = DateTime.UtcNow;

            this.Name = measure.Name;
            this.ShortName = measure.ShortName;
        }

        public virtual Measure Measure { get; set; }

        [ForeignKey(nameof(Measure))]
        public virtual long MeasureID { get; set; }

        public virtual AuditLog AuditLog { get; set; }

        public virtual long AuditLogID { get; set; }
    }
}
