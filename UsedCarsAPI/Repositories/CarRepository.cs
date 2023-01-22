using Microsoft.EntityFrameworkCore;
using UsedCarsAPI.Data;
using UsedCarsAPI.Models;
using UsedCarsAPI.Repositories.Interfaces;

namespace UsedCarsAPI.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly UsedCarsDBContext _dbContext;
        public CarRepository(UsedCarsDBContext usedCarsDBContext)
        {
            _dbContext= usedCarsDBContext;
        }
        public async Task<List<CarModel>> FindAllCars()
        {
            return await _dbContext.Cars.ToListAsync();
        }

        public async Task<CarModel> FindOneById(int id)
        {
            CarModel? carById = await _dbContext.Cars.FirstOrDefaultAsync(x => x.Id == id);
            
            if (carById == null)
            {
                throw new Exception($"Car Id: {id} not found");
            }

            return carById;
        }
        public async Task<CarModel> Create(CarModel car)
        {
            await _dbContext.Cars.AddAsync(car);
            await _dbContext.SaveChangesAsync();

            return car;
        }
        public async Task<string> UploadImage(IFormFile? image)
        {
            if (image == null)
            {
                throw new Exception("This image is not valid");
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", image.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            var ImagePath = "images/" + image.FileName;

            return ImagePath;
        }

        public async Task<CarModel> Update(CarModel car, int id)
        {
            CarModel carById = await FindOneById(id);

            if (carById == null)
            {
                throw new Exception($"Car Id: {id} not found");
            }

            carById.Name = car.Name;
            carById.Model = car.Model;
            carById.Brand = car.Brand;
            carById.Image = car.Image;


            _dbContext.Cars.Update(carById);
            await _dbContext.SaveChangesAsync();

            return carById;
        }

        public async Task<bool> Delete(int id)
        {
            CarModel carById = await FindOneById(id);

            if (carById == null)
            {
                throw new Exception($"Car Id: {id} not found");
            }

            _dbContext.Cars.Remove(carById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
