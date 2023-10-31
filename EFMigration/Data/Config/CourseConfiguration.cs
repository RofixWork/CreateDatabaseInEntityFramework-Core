using EFMigration.Entities;
using Microsoft.EntityFrameworkCore;
using System;
namespace EFMigration.Data.Config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Course> builder)
        {
            //config
            builder.HasKey(course => course.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Property(c => c.CourseName).HasColumnType("varchar").HasMaxLength(maxLength: 200).IsRequired();
            builder.Property(c => c.Price).HasPrecision(15, 2).IsRequired();
            builder.ToTable(name: "Courses");

            //builder.HasData(GetCourses());
        }

        //private static List<Course> GetCourses()
        //{
        //    return new List<Course>() {
        //        new Course { Id=1, CourseName="Mathematics", Price=1000.00m},
        //        new Course { Id=2, CourseName="Physics", Price=2000.00m},
        //        new Course { Id=3, CourseName="Chemistry", Price=1500.00m},
        //        new Course { Id=4, CourseName="Biology", Price=1200.00m},
        //        new Course { Id=5, CourseName="Computer", Price=3000.00m},
        //    };
        //}
    }

}
