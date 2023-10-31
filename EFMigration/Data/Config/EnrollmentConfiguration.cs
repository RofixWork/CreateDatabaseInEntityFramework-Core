using EFMigration.Entities;
using Microsoft.EntityFrameworkCore;
namespace EFMigration.Data.Config
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Enrollment> builder)
        {
            //config
            builder.HasKey(s => new {s.StudentId, s.SectionId});

            builder.ToTable(name: "Enrollments");

            //builder.HasData(LoadEnrollments());
        }

        //private static List<Enrollment> LoadEnrollments() => new()
        //{
        //    new Enrollment {StudentId=1, SectionId=6},
        //    new Enrollment {StudentId=2, SectionId=6},
        //    new Enrollment {StudentId=3, SectionId=7},
        //    new Enrollment {StudentId=4, SectionId=7},
        //    new Enrollment {StudentId=5, SectionId=8},
        //    new Enrollment {StudentId=6, SectionId=8},
        //    new Enrollment {StudentId=7, SectionId=9},
        //    new Enrollment {StudentId=8, SectionId=9},
        //    new Enrollment {StudentId=9, SectionId=10},
        //    new Enrollment {StudentId=10, SectionId=10},
        //};
    }
}
