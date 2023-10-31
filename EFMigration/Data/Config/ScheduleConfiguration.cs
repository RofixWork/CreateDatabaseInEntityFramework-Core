using EFMigration.Entities;
using EFMigration.Enums;
using Microsoft.EntityFrameworkCore;
namespace EFMigration.Data.Config
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Schedule> builder)
        {
            //config
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedNever();
            //builder.Property(s => s.Title).HasColumnType("varchar").HasMaxLength(maxLength: 100).IsRequired();
            builder.Property(p => p.Title).HasConversion(
                x => x.ToString(),
                x => (ScheduleEnum)Enum.Parse(typeof(ScheduleEnum), x)
            ).HasColumnType("varchar").HasMaxLength(maxLength: 100).IsRequired();
            builder.Property(p => p.SUN).IsRequired();
            builder.Property(p => p.MON).IsRequired();
            builder.Property(p => p.TUE).IsRequired();
            builder.Property(p => p.WED).IsRequired();
            builder.Property(p => p.THU).IsRequired();
            builder.Property(p => p.FRI).IsRequired();
            builder.Property(p => p.SAT).IsRequired();
            builder.ToTable(name: "Schedules");

            //builder.HasData(LoadSchedules());
        }

        //private static List<Schedule> LoadSchedules()
        //{
        //    return new List<Schedule>() {
        //        new Schedule {Id=1, Title="Daily", SUN=true,MON=true,TUE=true,WED=true,THU=true,FRI=false,SAT=false},
        //        new Schedule {Id=2, Title="DayAfterDay", SUN=true,MON=false,TUE=true,WED=false,THU=true,FRI=false,SAT=false},
        //        new Schedule {Id=3, Title="Twice-a-Week", SUN=false,MON=true,TUE=false,WED=true,THU=false,FRI=false,SAT=false},
        //        new Schedule {Id=4, Title="Weekend", SUN=false,MON=false,TUE=false,WED=false,THU=false,FRI=true,SAT=true},
        //        new Schedule {Id=5, Title="Compact", SUN=true,MON=true,TUE=true,WED=true,THU=true,FRI=true,SAT=true},
        //    };
        //}
    }
}
