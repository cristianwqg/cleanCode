using Microsoft.AspNetCore.Mvc;
using MediatR;
using Pronabec.UseCases.Personas.Commands.CreatePersonaCommand;
using Pronabec.UseCases.Personas.Commands.UpdatePersonaCommand;
using Pronabec.UseCases.Personas.Commands.DeletePersonaCommand;
using Pronabec.UseCases.Personas.Queries.GetPersonaQuery;
using Pronabec.UseCases.Personas.Queries.GetAllPersonaQuery;

namespace Pronabec.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreatePersonaCommand createPersonaCommand)
        {
            var response = await _mediator.Send(createPersonaCommand);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdatePersonaCommand updatePersonaCommand)
        {
            var response = await _mediator.Send(updatePersonaCommand);
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var response = await _mediator.Send(new DeletePersonaCommand() { Id = id });
            return Ok(response);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetPersonaQuery() { Id = id });
            return Ok(response);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GenerarPDF([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetPersonaQuery() { Id = id });
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllPersonaQuery());
            return Ok(response);
        }
    }
}
