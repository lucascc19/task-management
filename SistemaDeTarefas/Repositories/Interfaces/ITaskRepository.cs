using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetTaskList();
        Task<TaskModel> GetTaskById(int id);
        Task<TaskModel> AddTask(TaskModel task);
        Task<TaskModel> UpdateTask(TaskModel task, int id);
        Task<bool> DeleteTask(int id);
    }
}
