using UsedCarsAPI.Models;

namespace UsedCarsAPI.Repositories.Interfaces
{
    public interface ICarRepository
    {
        Task<List<CarModel>> FindAllCars();
        Task<CarModel> FindOneById(int id);
        Task<CarModel> Create(CarModel car);
        Task<CarModel> Update(CarModel car, int id);
        Task<string> UploadImage(IFormFile file);
        Task<bool> Delete(int id);
    }
}
