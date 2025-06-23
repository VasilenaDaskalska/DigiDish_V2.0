using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DigiDish.BusinessModels.ENUMS;
using DigiDish.Entities.Contracts;

namespace DigiDish.Entities.BaseEntities
{
    public abstract class UserBaseEntity : BaseEntity, IDeletable, IAuditInfo
    {
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DefaultValue(PERMISSIONS.None)]
        public PERMISSIONS UserPermissions { get; set; }

        public byte[]? ProfilePhoto { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual long UserCreatorID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        public virtual long LastUserModifiedID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LastModifiedDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? LastPasswordModifiedDate { get; set; }
    }
}
