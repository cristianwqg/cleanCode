using Microsoft.AspNetCore.Mvc;
using MediatR;
using Pronabec.UseCases.Compromiso.Commands.CreateCompromisoCommand;
using Pronabec.UseCases.Compromiso.Commands.UpdateCompromisoCommand;
using Pronabec.UseCases.Compromiso.Commands.DeleteCompromisoCommand;
using Pronabec.UseCases.Compromiso.Queries.GetCompromisoQuery;
using Pronabec.UseCases.Compromiso.Queries.GetAllCompromisoQuery;

namespace Pronabec.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompromisoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompromisoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateCompromisoCommand createCompromisoCommand)
        {
            var response = await _mediator.Send(createCompromisoCommand);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCompromisoCommand updateCompromisoCommand)
        {
            var response = await _mediator.Send(updateCompromisoCommand);
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var response = await _mediator.Send(new DeleteCompromisoCommand() { Id = id });
            return Ok(response);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetCompromisoQuery() { Id = id });
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllCompromisoQuery());
            return Ok(response);
        }
    }
}
