using UsedCarsAPI.Models;

namespace UsedCarsAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> FindAllUsers();
        Task<UserModel> FindUserById(int id);
        Task<UserModel> Create(UserModel car);
        Task<UserModel> Update(UserModel car, int id);
        Task<bool> Delete(int id);
    }
}
