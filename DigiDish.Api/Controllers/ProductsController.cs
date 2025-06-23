using DigiDish.BusinessModels.Products;
using DigiDish.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DigiDish.Api.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await this.productService.GetAllAsync();

                if (products == null)
                {
                    return this.NotFound();
                }

                return this.Ok(products);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }


        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var product = await this.productService.GetByIdAsync(id);

                if (product == null)
                {
                    return this.NotFound();
                }

                return this.Ok(product);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductBiz model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.BadRequest(this.ModelState);
                }

                var updated = await this.productService.UpdateAsync(model);

                if (updated == null)
                {
                    return this.NotFound();
                }

                return this.Ok(updated);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await this.productService.DeleteAsync(id);

                if (!result)
                {
                    return this.NotFound();
                }

                return this.NoContent();
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductBiz model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.BadRequest(this.ModelState);
                }

                var created = await this.productService.CreateAsync(model);

                if (created == null)
                {
                    return this.BadRequest("Failed to create product");
                }

                return this.CreatedAtAction(nameof(Get), new { id = created.ID }, created);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}