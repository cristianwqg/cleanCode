using Microsoft.AspNetCore.Mvc;
using MediatR;
using Pronabec.UseCases.Instituciones.Commands.CreateInstitucionCommand;
using Pronabec.UseCases.Instituciones.Commands.UpdateInstitucionCommand;
using Pronabec.UseCases.Instituciones.Commands.DeleteInstitucionCommand;
using Pronabec.UseCases.Instituciones.Queries.GetInstitucionQuery;
using Pronabec.UseCases.Instituciones.Queries.GetAllInstitucionQuery;

namespace Pronabec.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstitucionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InstitucionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateInstitucionCommand createInstitucionCommand)
        {
            var response = await _mediator.Send(createInstitucionCommand);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateInstitucionCommand updateInstitucionCommand)
        {
            var response = await _mediator.Send(updateInstitucionCommand);
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var response = await _mediator.Send(new DeleteInstitucionCommand() { Id = id });
            return Ok(response);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetInstitucionQuery() { Id = id });
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllInstitucionQuery());
            return Ok(response);
        }
    }
}
