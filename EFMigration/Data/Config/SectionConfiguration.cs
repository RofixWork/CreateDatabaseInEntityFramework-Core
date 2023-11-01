using EFMigration.Entities;
using Microsoft.EntityFrameworkCore;
namespace EFMigration.Data.Config
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Section> builder)
        {
            //config
            builder.HasKey(s => s.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Property(c => c.SectionName).HasColumnType("varchar").HasMaxLength(maxLength: 50).IsRequired();
            builder.ToTable(name: "Sections");

            builder.OwnsOne(section => section.TimeSlot, build =>
            {
                build.Property(p => p.StartTime).HasColumnType("time").HasColumnName("StartTime").IsRequired();
                build.Property(p => p.EndTime).HasColumnType("time").HasColumnName("EndTime").IsRequired();
            });

            builder.HasOne(s => s.Course)
                .WithMany(c => c.Sections)
                .HasForeignKey(c => c.CourseId)
                .IsRequired();

            builder.HasOne(s => s.Instructor)
                .WithMany(c => c.Sections)
                .HasForeignKey(c => c.InstructorId)
                .IsRequired(false);

            builder.HasOne(s => s.Schedule)
                .WithMany(s => s.Sections)
                .HasForeignKey(s => s.ScheduleId).IsRequired();

            builder.HasMany(s => s.Participants)
                .WithMany(s => s.Sections)
                .UsingEntity<Enrollment>();



            //builder.HasData(LoadSections());
        }

//        private static List<Section> LoadSections() => new()
//        {
//            new Section {Id=1, SectionName="S_MA1", CourseId=1 ,InstructorId=1, ScheduleId=1, StartTime=TimeSpan.Parse("08:00:00"), EndTime=TimeSpan.Parse("10:00:00")
//},
//            new Section {Id=2, SectionName="S_MA2", CourseId=1 ,InstructorId=2,ScheduleId=3, StartTime=TimeSpan.Parse("14:00:00"), EndTime=TimeSpan.Parse("18:00:00")
// },
//            new Section {Id=3, SectionName="S_PH1", CourseId=2 ,InstructorId=1,ScheduleId=4, StartTime=TimeSpan.Parse("10:00:00"), EndTime=TimeSpan.Parse("15:00:00")
// },
//            new Section {Id=4, SectionName="S_PH2", CourseId=2 ,InstructorId=3,ScheduleId=1, StartTime=TimeSpan.Parse("10:00:00"), EndTime=TimeSpan.Parse("12:00:00")
// },
//            new Section {Id=5, SectionName="S_CH1", CourseId=3 ,InstructorId=2, ScheduleId=1, StartTime=TimeSpan.Parse("16:00:00"), EndTime=TimeSpan.Parse("18:00:00")
//},
//            new Section {Id=6, SectionName="S_CH2", CourseId=3 ,InstructorId=3,ScheduleId=2, StartTime=TimeSpan.Parse("08:00:00"), EndTime=TimeSpan.Parse("10:00:00")
// },
//            new Section {Id=7, SectionName="S_BI1", CourseId=4 ,InstructorId=4,ScheduleId=3, StartTime=TimeSpan.Parse("11:00:00"), EndTime=TimeSpan.Parse("14:00:00")
// },
//            new Section {Id=8, SectionName="S_BI2", CourseId=4 ,InstructorId=5,ScheduleId=4, StartTime=TimeSpan.Parse("10:00:00"), EndTime=TimeSpan.Parse("14:00:00")
// },
//            new Section {Id=9, SectionName="S_CS1", CourseId=5 ,InstructorId=4, ScheduleId=4, StartTime=TimeSpan.Parse("16:00:00"), EndTime=TimeSpan.Parse("18:00:00")},
//            new Section {Id=10, SectionName="S_CS2", CourseId=5,InstructorId=5,ScheduleId=3, StartTime=TimeSpan.Parse("08:00:00"), EndTime=TimeSpan.Parse("10:00:00") },
//            new Section {Id=11, SectionName="S_CS3", CourseId=5,InstructorId=4, ScheduleId=4, StartTime=TimeSpan.Parse("16:00:00"), EndTime=TimeSpan.Parse("18:00:00")},
//        };
    }
}
