using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetTaskList()
        {
            List<TaskModel> taskList =  await _taskRepository.GetTaskList();
            return Ok(taskList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskById(int id)
        {
            TaskModel taskId = await _taskRepository.GetTaskById(id);
            return Ok(taskId);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> AddTask([FromBody] TaskModel taskModel)
        {
            TaskModel task = await _taskRepository.AddTask(taskModel);
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> UpdateTask([FromBody] TaskModel taskModel, int id)
        {
            taskModel.Id = id;
            TaskModel task = await _taskRepository.UpdateTask(taskModel, id);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> DeleteTask(int id)
        {
            bool delete = await _taskRepository.DeleteTask(id);
            return Ok(delete);
        }
    }
}
