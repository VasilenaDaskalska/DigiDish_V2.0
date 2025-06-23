using DigiDish.BusinessModels.Measures;
using DigiDish.Entities;
using DigiDish.Entities.AuditTriailEntities;
using DigiDish.HttpRepository.Contracts;
using DigiDish.Mappers;
using DigiDish.Services.Contracts;

namespace DigiDish.Services
{
    public class MeasureService : IMeasureService
    {
        private readonly IRepository<Measure> measureRepository;
        private readonly IRepository<MeasureLog> measureLogRepository;
        private readonly IRepository<AuditLog> auditLogRepository;

        public MeasureService(
            IRepository<Measure> measureRepo,
            IRepository<MeasureLog> measureLogRepo,
            IRepository<AuditLog> auditLogRepo)
        {
            this.measureRepository = measureRepo;
            this.measureLogRepository = measureLogRepo;
            this.auditLogRepository = auditLogRepo;
        }

        public async Task<MeasureBiz?> GetByIdAsync(long id)
        {
            try
            {
                var measure = await this.measureRepository.GetByIdAsync(id);
                return (measure == null || measure.IsDeleted)
                    ? null
                    : MeasureMapper.MapMeasureBizFromMeasureEntity(measure);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get measure {ex.Message}");
            }

        }

        public async Task<IEnumerable<MeasureBiz>> GetAllAsync()
        {
            try
            {
                var measures = await this.measureRepository.GetAllAsync();
                return measures
                    .Where(p => !p.IsDeleted)
                    .Select(MeasureMapper.MapMeasureBizFromMeasureEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get measures {ex.Message}");
            }
        }

        public async Task<MeasureBiz> CreateAsync(MeasureBiz model)
        {
            try
            {
                var entity = MeasureMapper.MapMeasureEntityFromMeasureBiz(model);
                var created = await this.measureRepository.AddAsync(entity);

                //// await this.LogChange(created, model.UserCreatorID);
                return MeasureMapper.MapMeasureBizFromMeasureEntity(created);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create measure {ex.Message}");
            }

        }

        public async Task<MeasureBiz> UpdateAsync(MeasureBiz model)
        {
            try
            {
                var existing = await this.measureRepository.GetByIdAsync(model.ID);

                if (existing == null || existing.IsDeleted)
                {
                    throw new Exception("Measure not found.");
                }

                MeasureMapper.MapMeasureEntityFromMeasureBiz(ref existing, ref model);
                await this.measureRepository.UpdateAsync(existing);
                await this.LogChange(existing, model.LastUserModifiedID);

                return await this.GetByIdAsync(model.ID);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update measure {ex.Message}");
            }

        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var entity = await this.measureRepository.GetByIdAsync(id);
                long userId = 19;

                if (entity == null || entity.IsDeleted)
                {
                    throw new Exception("Measure not found.");
                }

                entity.IsDeleted = true;
                entity.LastModifiedDate = DateTime.UtcNow;
                entity.LastUserModifiedID = userId;

                await this.measureRepository.UpdateAsync(entity);
                await this.LogChange(entity, userId);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete measure {ex.Message}");
            }
        }

        private async Task LogChange(Measure measure, long userId)
        {
            var auditLog = new AuditLog(userId)
            {
                CreationDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow
            };

            var createdAuditLog = await this.auditLogRepository.AddAsync(auditLog);
            var productLog = new MeasureLog(measure, userId)
            {
                AuditLogID = createdAuditLog.ID,
                MeasureID = measure.ID,
            };

            await this.measureLogRepository.AddAsync(productLog);
        }
    }
}
