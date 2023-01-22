using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsedCarsAPI.Models;

namespace UsedCarsAPI.Data.Map
{
    public class CarMap : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Brand).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Model).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Image).IsRequired();
        }
    }
}
