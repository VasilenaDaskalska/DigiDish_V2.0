using System.Linq.Expressions;
using DigiDish.BusinessModels.Measures;
using DigiDish.Entities;

namespace DigiDish.Mappers
{
    public class MeasureMapper
    {
        public static Expression<Func<Measure, MeasureBiz>> SelectMeasureBizFromMeasureEntity => (measureEntity) => new MeasureBiz()
        {
            ID = measureEntity.ID,
            Name = measureEntity.Name,
            ShortName = measureEntity.ShortName,
            UserCreatorID = measureEntity.UserCreatorID,
            LastUserModifiedID = measureEntity.LastUserModifiedID,
            CreationDate = measureEntity.CreationDate.ToUniversalTime(),
            LastModifiedDate = measureEntity.LastModifiedDate.ToUniversalTime(),
            IsDeleted = measureEntity.IsDeleted,
        };

        public static void MapMeasureEntityFromMeasureBiz(ref Measure measureEntity, ref MeasureBiz measureBiz)
        {
            measureEntity.ID = measureBiz.ID;
            measureEntity.Name = measureBiz.Name;
            measureEntity.ShortName = measureBiz.ShortName;
            measureEntity.UserCreatorID = measureBiz.UserCreatorID;
            measureEntity.LastUserModifiedID = measureBiz.LastUserModifiedID;
            measureEntity.CreationDate = measureBiz.CreationDate.UtcDateTime;
            measureEntity.LastModifiedDate = measureBiz.LastModifiedDate.UtcDateTime;
            measureEntity.IsDeleted = measureBiz.IsDeleted;
        }


        public static MeasureBiz MapMeasureBizFromMeasureEntity(Measure measureEntity)
        {
            return new MeasureBiz()
            {
                ID = measureEntity.ID,
                Name = measureEntity.Name,
                UserCreatorID = measureEntity.UserCreatorID,
                LastUserModifiedID = measureEntity.LastUserModifiedID,
                CreationDate = measureEntity.CreationDate.ToUniversalTime(),
                LastModifiedDate = measureEntity.LastModifiedDate.ToUniversalTime(),
                IsDeleted = measureEntity.IsDeleted,
                ShortName = measureEntity.ShortName,
            };
        }

        public static Measure MapMeasureEntityFromMeasureBiz(MeasureBiz measureBiz)
        {
            return new Measure()
            {
                ID = measureBiz.ID,
                Name = measureBiz.Name,
                UserCreatorID = measureBiz.UserCreatorID,
                LastUserModifiedID = measureBiz.LastUserModifiedID,
                CreationDate = measureBiz.CreationDate.UtcDateTime,
                LastModifiedDate = measureBiz.LastModifiedDate.UtcDateTime,
                IsDeleted = measureBiz.IsDeleted,
                ShortName = measureBiz.ShortName,
            };
        }
    }
}
