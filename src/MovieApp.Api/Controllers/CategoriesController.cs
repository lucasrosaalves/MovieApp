using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.UseCases.Commands;
using MovieApp.Core.UseCases.Queries;
using System;
using System.Threading.Tasks;

namespace MovieApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] GetCategoriesQuery service, [FromQuery] string name)
        {
            return Ok(await service.HandleAsync(name));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromServices] GetCategoryByIdQuery service, [FromRoute] Guid id)
        {
            return Ok(await service.HandleAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] CreateCategoryCommand service, [FromBody] CreateCategoryCommand.CreateCategoryRequest model)
        {
            await service.HandleAsync(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromServices] DeleteCategoryCommand service, [FromRoute] Guid id)
        {
            await service.HandleAsync(id);
            return Ok();
        }
    }
}
