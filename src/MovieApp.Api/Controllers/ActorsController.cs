using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.UseCases.Commands;
using MovieApp.Core.UseCases.Queries;
using System;
using System.Threading.Tasks;

namespace MovieApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] GetActorsQuery service, [FromQuery] string name)
        {
            return Ok(await service.HandleAsync(name));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromServices] GetActorByIdQuery service, [FromRoute] Guid id)
        {
            return Ok(await service.HandleAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] CreateActorCommand service, [FromBody] CreateActorCommand.CreateActorRequest model)
        {
            await service.HandleAsync(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromServices] DeleteActorCommand service, [FromRoute] Guid id)
        {
            await service.HandleAsync(id);
            return Ok();
        }
    }
}
