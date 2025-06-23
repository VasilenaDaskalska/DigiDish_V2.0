using DigiDish.BusinessModels.Measures;
using DigiDish.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DigiDish.Api.Controllers
{
    [ApiController]
    [Route("api/measures")]
    public class MeasureController : ControllerBase
    {
        private readonly IMeasureService measureService;

        public MeasureController(IMeasureService measureService)
        {
            this.measureService = measureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var measures = await this.measureService.GetAllAsync();

                if (measures == null)
                {
                    return this.NotFound();
                }

                return this.Ok(measures);
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
                var measure = await this.measureService.GetByIdAsync(id);

                if (measure == null)
                {
                    return this.NotFound();
                }

                return this.Ok(measure);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MeasureBiz model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.BadRequest(this.ModelState);
                }

                var updated = await this.measureService.UpdateAsync(model);

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
                var result = await this.measureService.DeleteAsync(id);

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
        public async Task<IActionResult> Create([FromBody] MeasureBiz model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.BadRequest(this.ModelState);
                }

                var created = await this.measureService.CreateAsync(model);

                if (created == null)
                {
                    return this.BadRequest("Failed to create measure");
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
