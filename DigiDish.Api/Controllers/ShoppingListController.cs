using DigiDish.BusinessModels.ShoppingLists;
using DigiDish.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DigiDish.Api.Controllers
{
    [ApiController]
    [Route("api/shopping-list")]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService)
        {
            this.shoppingListService = shoppingListService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var shoppingLists = await this.shoppingListService.GetAllAsync();

                if (shoppingLists == null)
                {
                    return this.NotFound();
                }

                return this.Ok(shoppingLists);
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
                var shoppingList = await this.shoppingListService.GetByIdAsync(id);

                if (shoppingList == null)
                {
                    return this.NotFound();
                }

                return this.Ok(shoppingList);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ShoppingListBiz model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.BadRequest(this.ModelState);
                }

                var updated = await this.shoppingListService.UpdateAsync(model);

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
                var result = await this.shoppingListService.DeleteAsync(id);

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
        public async Task<IActionResult> Create([FromBody] ShoppingListBiz model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.BadRequest(this.ModelState);
                }

                var created = await this.shoppingListService.CreateAsync(model);

                if (created == null)
                {
                    return this.BadRequest("Failed to create shopping list");
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
