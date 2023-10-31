using EFMigration.Entities;
using Microsoft.EntityFrameworkCore;
namespace EFMigration.Data.Config
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Office> builder)
        {
            //config
            builder.HasKey(course => course.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Property(c => c.OfficeName).HasColumnType("varchar").HasMaxLength(maxLength: 50).IsRequired();
            builder.Property(c => c.OfficeLocation).HasColumnType("varchar").HasMaxLength(maxLength: 50).IsRequired();
            builder.ToTable(name: "Offices");

            //builder.HasData(GetOffices());
        }

        //private static List<Office> GetOffices() => new() {
        //    new Office {Id=1, OfficeName="Off_05", OfficeLocation="Building A"},
        //    new Office {Id=2, OfficeName="Off_12", OfficeLocation="Building B"},
        //    new Office {Id=3, OfficeName="Off_32", OfficeLocation="Adminstration"},
        //    new Office {Id=4, OfficeName="Off_44", OfficeLocation="IT Department"},
        //    new Office {Id=5, OfficeName="Off_43", OfficeLocation="IT Department"},
        //};
        
    }

}
