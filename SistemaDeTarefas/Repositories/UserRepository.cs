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

        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.AddAsync(user);
            _dbContext.SaveChanges();

            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userId = await GetUserById(id);

            if(userId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            userId.Name = user.Name;
            userId.Email = user.Email;

            _dbContext.User.Update(userId);
            _dbContext.SaveChanges();

            return userId;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userId = await GetUserById(id);

            if (userId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.User.Remove(userId);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
