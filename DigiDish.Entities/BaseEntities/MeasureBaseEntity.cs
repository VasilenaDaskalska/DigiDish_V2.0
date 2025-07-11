﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DigiDish.Entities.Contracts;

namespace DigiDish.Entities.BaseEntities
{
    public abstract class MeasureBaseEntity : BaseEntity, IDeletable, IAuditInfo
    {
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortName { get; set; }

        public virtual long UserCreatorID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        public virtual long LastUserModifiedID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LastModifiedDate { get; set; }
    }
}
