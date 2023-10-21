using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetUserList();
        Task<UserModel> GetUserById(int id);
        Task<UserModel> AddUser(UserModel usuario);
        Task<UserModel> UpdateUser(UserModel usuario, int id);
        Task<bool> DeleteUser(int id);
    }
}
