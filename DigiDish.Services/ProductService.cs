using DigiDish.BusinessModels.Products;
using DigiDish.Entities;
using DigiDish.Entities.AuditTriailEntities;
using DigiDish.HttpRepository.Contracts;
using DigiDish.Mappers;
using DigiDish.Services.Contracts;

namespace DigiDish.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<ProductLog> productLogRepository;
        private readonly IRepository<AuditLog> auditLogRepository;

        public ProductService(
            IRepository<Product> productRepo,
            IRepository<ProductLog> productLogRepo,
            IRepository<AuditLog> auditLogRepo)
        {
            this.productRepository = productRepo;
            this.productLogRepository = productLogRepo;
            this.auditLogRepository = auditLogRepo;
        }

        public async Task<ProductBiz?> GetByIdAsync(long id)
        {
            try
            {
                var product = await this.productRepository.GetByIdAsync(id);
                return (product == null || product.IsDeleted)
                    ? null
                    : ProductMapper.MapProductBizFromProductEntity(product);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get product {ex.Message}");
            }

        }

        public async Task<IEnumerable<ProductBiz>> GetAllAsync()
        {
            try
            {
                var products = await this.productRepository.GetAllAsync();
                return products
                    .Where(p => !p.IsDeleted)
                    .Select(ProductMapper.MapProductBizFromProductEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get products {ex.Message}");
            }
        }

        public async Task<ProductBiz> CreateAsync(ProductBiz model)
        {
            try
            {
                var entity = ProductMapper.MapProductEntityFromProductBiz(model);
                var created = await this.productRepository.AddAsync(entity);

                await this.LogChange(created, model.UserCreatorID);
                return ProductMapper.MapProductBizFromProductEntity(created);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create product {ex.Message}");
            }

        }

        public async Task<ProductBiz> UpdateAsync(ProductBiz model)
        {
            try
            {
                var existing = await this.productRepository.GetByIdAsync(model.ID);

                if (existing == null || existing.IsDeleted)
                {
                    throw new Exception("Product not found.");
                }

                ProductMapper.MapProductEntityFromProductBiz(ref existing, ref model);
                await this.productRepository.UpdateAsync(existing);
                await this.LogChange(existing, model.LastUserModifiedID);

                return await this.GetByIdAsync(model.ID);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update product {ex.Message}");
            }

        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var entity = await this.productRepository.GetByIdAsync(id);
                long userId = 19;

                if (entity == null || entity.IsDeleted)
                {
                    throw new Exception("Product not found.");
                }

                entity.IsDeleted = true;
                entity.LastModifiedDate = DateTime.UtcNow;
                entity.LastUserModifiedID = userId;

                await this.productRepository.UpdateAsync(entity);
                await this.LogChange(entity, userId);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete product {ex.Message}");
            }
        }

        private async Task LogChange(Product product, long userId)
        {
            var auditLog = new AuditLog(userId)
            {
                CreationDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow
            };

            var createdAuditLog = await this.auditLogRepository.AddAsync(auditLog);
            var productLog = new ProductLog(product, userId)
            {
                AuditLogID = createdAuditLog.ID,
                ProductID = product.ID,
            };

            await this.productLogRepository.AddAsync(productLog);
        }
    }
}
