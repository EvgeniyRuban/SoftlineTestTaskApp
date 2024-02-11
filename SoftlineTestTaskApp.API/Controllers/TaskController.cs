using Microsoft.AspNetCore.Mvc;
using SoftlineTestTaskApp.Domain.Dto;
using SoftlineTestTaskApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SoftlineTestTaskApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        [HttpGet("{id}")]
        public async System.Threading.Tasks.Task<ActionResult<TaskDto>> Get([FromRoute]
        Guid id, CancellationToken
            cancellationToken)
        {
            return await _taskService.Get(id, cancellationToken);
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult<List<TaskDto>>> GetAll(CancellationToken cancellationToken)
        {
            var tasks = await _taskService.GetAll(cancellationToken);
            return Ok(tasks);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult<Guid>> Add(
            [FromBody] TaskCreateRequest request,
            CancellationToken cancellationToken)
        {
            return await _taskService.Add(request, cancellationToken);
        }

        [HttpPut]
        public async System.Threading.Tasks.Task<ActionResult> Update(
            [FromBody] TaskUpdateRequest request,
            CancellationToken cancellationToken)
        {
            await _taskService.Update(request, cancellationToken);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async System.Threading.Tasks.Task<ActionResult> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            await _taskService.Delete(id, cancellationToken);
            return Ok();
        }
    }
}
