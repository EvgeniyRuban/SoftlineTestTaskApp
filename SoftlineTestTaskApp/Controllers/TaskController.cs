using Microsoft.AspNetCore.Mvc;
using SoftlineTestTaskApp.Domain.Services;
using SoftlineTestTaskApp.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SoftlineTestTaskApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IStatusService _statusService;

        public TaskController(ITaskService taskService, IStatusService statusService)
        {
            _taskService = taskService;
            _statusService = statusService;
        }

        public async Task<IActionResult> Create()
        {
            var statuses = await _statusService.GetAll();
            return View(statuses);
        }

        public async System.Threading.Tasks.Task<IActionResult> Index()
        {
            var tasks = await _taskService.GetAll();
            return View(tasks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
