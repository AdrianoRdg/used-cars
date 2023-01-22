using Microsoft.EntityFrameworkCore;
using UsedCarsAPI.Data.Map;
using UsedCarsAPI.Models;

namespace UsedCarsAPI.Data
{
    public class UsedCarsDBContext : DbContext
    {
        public UsedCarsDBContext(DbContextOptions<UsedCarsDBContext> options) 
            : base(options)
        {
        }

        public DbSet<CarModel> Cars { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
