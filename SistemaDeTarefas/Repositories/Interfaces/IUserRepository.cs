using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetUserList();
        Task<UserModel> GetUserById(int id);
        Task<UserModel> AddUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user, int id);
        Task<bool> DeleteUser(int id);
    }
}
