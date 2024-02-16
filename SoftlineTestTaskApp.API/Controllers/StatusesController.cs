using Microsoft.AspNetCore.Mvc;
using SoftlineTestTaskApp.Domain.Dto;
using SoftlineTestTaskApp.Domain.Exceptions;
using SoftlineTestTaskApp.Domain.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SoftlineTestTaskApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusesController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusesController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusDto>> Get(
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _statusService.Get(id, cancellationToken));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<StatusDto>>> GetAll(CancellationToken cancellationToken)
        {
            var statuses = await _statusService.GetAll(cancellationToken);
            return Ok(statuses);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add(
            [FromBody] StatusCreateRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _statusService.Add(request, cancellationToken));
            }
            catch (EntityAlreadyExistsException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(
            [FromBody] StatusUpdateRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                await _statusService.Update(request, cancellationToken);
                return NoContent();
            }
            catch(EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(EntityAlreadyExistsException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            try
            {
                await _statusService.Delete(id, cancellationToken);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}