using DigiDish.BusinessModels.ENUMS;

namespace DigiDish.BusinessModels.Users
{
    public class UserBaseBiz
    {
        public long ID { get; set; }

        public bool IsDeleted { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public byte[]? ProfilePhoto { get; set; }

        public string Password { get; set; }

        public virtual long UserCreatorID { get; set; }

        public DateTime CreationDate { get; set; }

        public long LastUserModifiedID { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public DateTime? LastPasswordModifiedDate { get; set; }

        public PERMISSIONS UserPermission { get; set; }

    }
}
