namespace UsedCarsAPI.Models
{
    public class CarModelWithImage
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public IFormFile? Image { get; set; }
    }
}
