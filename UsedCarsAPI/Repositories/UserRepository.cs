using UsedCarsAPI.Models;
using UsedCarsAPI.Data;
using UsedCarsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UsedCarsAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UsedCarsDBContext _dbContext;

        public UserRepository(UsedCarsDBContext usedCarsDBContext)
        {
            _dbContext = usedCarsDBContext;
        }

        public async Task<List<UserModel>> FindAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> FindUserById(int id)
        {
            UserModel? user =await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            
            if (user == null)
            {
                throw new Exception($"User Id: {id} not found");
            }

            return user;
        }
        public async Task<UserModel> Create(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userById = await FindUserById(id);

            if (userById == null)
            {
                throw new Exception($"User Id: {id} not found");
            }

            userById.Name = user.Name;


            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userById = await FindUserById(id);

            if (userById == null)
            {
                throw new Exception($"User Id: {id} not found");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
