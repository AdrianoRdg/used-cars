using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsedCarsAPI.Models;
using UsedCarsAPI.Repositories.Interfaces;

namespace UsedCarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarModel>>> FindAllCars()
        {
            List<CarModel> cars = await _carRepository.FindAllCars();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<CarModel>> FindOneById(int id)
        {
            CarModel car = await _carRepository.FindOneById(id);
            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<CarModel>> Create([FromForm] CarModelWithImage carModel)
        {
            var imagePath = await _carRepository.UploadImage(carModel.Image);

            CarModel car = new()
            {
                Name = carModel.Name,
                Brand = carModel.Brand,
                Model = carModel.Model,
                Image = imagePath,
            };

            CarModel createdCar = await _carRepository.Create(car);
            return Ok(createdCar);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CarModel>> Update([FromBody] CarModel carModel, int id)
        {
            carModel.Id = id;
            CarModel car = await _carRepository.Update(carModel, id);
            return Ok(car);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarModel>> Delete(int id)
        {
            bool deletedCar = await _carRepository.Delete(id);
            return Ok(deletedCar);
        }
    }
}