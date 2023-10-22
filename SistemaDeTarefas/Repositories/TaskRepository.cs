using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly SistemaTarefasDBContext _dbContext;

        public TaskRepository(SistemaTarefasDBContext sistemaTarefasDBContext) 
        {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            return await _dbContext.Task
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TaskModel>> GetTaskList()
        {
            return await _dbContext.Task.ToListAsync();
        }

        public async Task<TaskModel> AddTask(TaskModel task)
        {
            await _dbContext.AddAsync(task);
            _dbContext.SaveChanges();

            return task;
        }

        public async Task<TaskModel> UpdateTask(TaskModel task, int id)
        {
            TaskModel taskId = await GetTaskById(id);

            if(taskId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados.");
            }

            taskId.Name = task.Name;
            taskId.Description = task.Description;
            taskId.Status = task.Status;
            taskId.UserId = task.UserId;

            _dbContext.Task.Update(taskId);
            _dbContext.SaveChanges();

            return taskId;
        }

        public async Task<bool> DeleteTask(int id)
        {
            TaskModel taskId = await GetTaskById(id);

            if (taskId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Task.Remove(taskId);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
