namespace DigiDish.BusinessModels.BaseBiz
{
    public class AuditInfoBiz
    {
        public long UserCreatorID { get; set; }

        public DateTimeOffset CreationDate { get; set; }

        public long LastUserModifiedID { get; set; }

        public DateTimeOffset LastModifiedDate { get; set; }
    }
}
