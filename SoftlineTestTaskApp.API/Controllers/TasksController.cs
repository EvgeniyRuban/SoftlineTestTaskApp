using Microsoft.AspNetCore.Mvc;
using SoftlineTestTaskApp.Domain.Dto;
using SoftlineTestTaskApp.Domain.Exceptions;
using SoftlineTestTaskApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SoftlineTestTaskApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        [HttpGet("{id}")]
        public async System.Threading.Tasks.Task<ActionResult<TaskDto>> Get(
            [FromRoute] Guid id, 
            CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _taskService.Get(id, cancellationToken));
            }
            catch(EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult<List<TaskDto>>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _taskService.GetAll(cancellationToken));
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult<Guid>> Add(
            [FromBody] TaskCreateRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var id = await _taskService.Add(request, cancellationToken);
                return Ok(id);
            }
            catch(EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async System.Threading.Tasks.Task<ActionResult> Update(
            [FromBody] TaskUpdateRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                await _taskService.Update(request, cancellationToken);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async System.Threading.Tasks.Task<ActionResult> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            try
            {
                await _taskService.Delete(id, cancellationToken);
                return NoContent();
            }
            catch(EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
