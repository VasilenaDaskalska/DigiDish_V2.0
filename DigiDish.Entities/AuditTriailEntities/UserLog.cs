using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigiDish.Entities.BaseEntities;
using DigiDish.Entities.Contracts;

namespace DigiDish.Entities.AuditTriailEntities
{
    public class UserLog : UserBaseEntity, IAuditLog
    {
        public UserLog()
        {
        }

        public UserLog(User user, long userID)
        {
            this.AuditLog = new AuditLog(userID);
            this.UserCreatorID = userID;
            this.LastUserModifiedID = userID;
            this.CreationDate = DateTime.UtcNow;
            this.LastModifiedDate = DateTime.UtcNow;

            this.User = user;
            this.UserName = user.UserName;
            this.Password = user.Password;
            this.PhoneNumber = user.PhoneNumber;
            this.ProfilePhoto = user.ProfilePhoto;
            this.Email = user.Email;
            this.IsDeleted = user.IsDeleted;
            this.Name = user.Name;
            this.LastPasswordModifiedDate = user.LastPasswordModifiedDate;
        }

        public virtual User User { get; set; }

        [ForeignKey(nameof(User))]
        public long UserID { get; set; }

        public virtual User UserCreator { get; set; }

        [ForeignKey(nameof(UserCreator))]
        public override long UserCreatorID { get; set; }

        public virtual User LastUserModified { get; set; }

        [ForeignKey(nameof(LastUserModified))]
        public override long LastUserModifiedID { get; set; }

        public virtual AuditLog AuditLog { get; set; }

        [Required]
        [ForeignKey(nameof(AuditLog))]
        public virtual long AuditLogID { get; set; }
    }
}
