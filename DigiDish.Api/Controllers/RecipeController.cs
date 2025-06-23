using DigiDish.BusinessModels.Recipes;
using DigiDish.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DigiDish.Api.Controllers
{
    [ApiController]
    [Route("api/recipe")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var recipes = await this.recipeService.GetAllAsync();

                if (recipes == null)
                {
                    return this.NotFound();
                }

                return this.Ok(recipes);
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
                var recipe = await this.recipeService.GetByIdAsync(id);

                if (recipe == null)
                {
                    return this.NotFound();
                }

                return this.Ok(recipe);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RecipeBiz model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.BadRequest(this.ModelState);
                }

                var created = await this.recipeService.CreateAsync(model);

                if (created == null)
                {
                    return this.BadRequest("Failed to create recipe");
                }

                return this.CreatedAtAction(nameof(Get), new { id = created.ID }, created);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RecipeBiz model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.BadRequest(this.ModelState);
                }

                var updated = await this.recipeService.UpdateAsync(model);

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
                var result = await this.recipeService.DeleteAsync(id);

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
    }
}
