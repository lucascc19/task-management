using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SistemaTarefasDBContext _dbContext;

        public UserRepository(SistemaTarefasDBContext sistemaTarefasDBContext) 
        {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserModel>> GetUserList()
        {
            return await _dbContext.User.ToListAsync();
        }

        public async Task<UserModel> AddUser(UserModel usuario)
        {
            await _dbContext.AddAsync(usuario);
            _dbContext.SaveChanges();

            return usuario;
        }

        public async Task<UserModel> UpdateUser(UserModel usuario, int id)
        {
            UserModel usuarioPorId = await GetUserById(id);

            if(usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email;

            _dbContext.User.Update(usuarioPorId);
            _dbContext.SaveChanges();

            return usuarioPorId;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel usuarioPorId = await GetUserById(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.User.Remove(usuarioPorId);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
