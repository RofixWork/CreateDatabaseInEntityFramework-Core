using EFMigration.Entities;
using Microsoft.EntityFrameworkCore;
namespace EFMigration.Data.Config
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Instructor> builder)
        {
            //config
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedNever();
            builder.Property(i => i.FirstName).HasColumnType("varchar").HasMaxLength(maxLength: 50).IsRequired();
            builder.Property(i => i.LastName).HasColumnType("varchar").HasMaxLength(maxLength: 50).IsRequired();
            builder.ToTable(name: "Instructors");

            builder.HasOne(instructor => instructor.Office)
                .WithOne(office => office.Instructor)
                .HasForeignKey<Instructor>(i => i.OfficeId).IsRequired(required:false);

            builder.HasIndex(i => i.OfficeId).IsUnique();

            //builder.HasData(data:GetInstructors());
        }

        //private static List<Instructor> GetInstructors()
        //{
        //    return new List<Instructor>() {
        //        new Instructor { Id=1, FirstName="Ahmed",LastName= "Abdullah", OfficeId=1},
        //        new Instructor { Id=2, FirstName="Yasmeen",LastName="Mohammed", OfficeId=2 },
        //        new Instructor { Id=3, FirstName="Khalid",LastName="Hassan", OfficeId=3 },
        //        new Instructor { Id=4, FirstName="Nadia",LastName="Ali", OfficeId=4},
        //        new Instructor { Id=5, FirstName="Omar",LastName="Ibrahim", OfficeId=5},
        //    };
        //}
    }
}
