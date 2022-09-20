using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebTask.Lib.Core;
using WebTask.Lib.Service;

namespace WebTask.Controllers
{



    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMyTaskService _service;
        private readonly ILogger<TaskController> _logger;
        public TaskController(IMyTaskService service, ILogger<TaskController> logger)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Получить все задачи
        /// </summary>
        /// <returns>Все задачи</returns>
        [HttpGet]
        public async Task<IEnumerable<MyTask>> GetAsync()
        {
            return await _service.GetAsync();
        }

        /// <summary>
        /// Получить задачу по коду задачи
        /// </summary>
        /// <param name="Id">код задачи</param>
        /// <returns>Возвращает задачу по коду</returns>
        [HttpGet]
        [Route("{Id}")]
        public async Task<MyTask> GetAsync(int Id)
        {
            return await _service.GetAsync(Id);
        }

        [HttpPost]
        public async Task<MyTask> AddAsync(string taskName)
        {
            return await _service.Add(taskName);
        }

        [HttpPut]
        public async Task UpdateAsync(int Id,string taskName)
        {
             await _service.Update(Id,taskName);
        }

        [HttpDelete]
        public async Task DeleteAsync(int Id)
        {
            await _service.Delete(Id);
        }

    }
}
