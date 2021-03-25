using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bronistol.Commands;
using Bronistol.Core.Supports;
using Bronistol.Database.EntitiesDto;
using Bronistol.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bronistol.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BronistolController : ControllerBase
    {
        private IMediator _mediator;

        public BronistolController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route(nameof(BookTable))]
        public async Task<IActionResult> BookTable([FromBody] BookTableRequest bookTableRequest)
        {
            return await SendRequest(bookTableRequest);
        }

        [HttpPost]
        [Route(nameof(GetReservedTables))]
        public async Task<IActionResult> GetReservedTables([FromBody] GetReservedTablesCommand getReservedTablesCommand)
        {
            return await SendRequest(getReservedTablesCommand);
        }

        private async Task<IActionResult> SendRequest<T>(IRequest<T> request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}