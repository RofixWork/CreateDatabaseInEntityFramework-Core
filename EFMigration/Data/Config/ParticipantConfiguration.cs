using EFMigration.Entities;
using Microsoft.EntityFrameworkCore;
namespace EFMigration.Data.Config
{
    public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Participant> builder)
        {
            //config
            builder.HasKey(s => s.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Property(c => c.FName).HasColumnType("varchar").HasMaxLength(maxLength: 255).IsRequired();
            builder.Property(c => c.LName).HasColumnType("varchar").HasMaxLength(maxLength: 255).IsRequired();
            builder.ToTable(name: "Participants");

            //builder.HasDiscriminator<string>("ParticipantType").HasValue<Individual>("INDV").HasValue<Coporate>("COPR");

            //builder.Property("ParticipantType").HasColumnType("varchar").HasMaxLength(maxLength: 4);
            builder.UseTptMappingStrategy();
            //builder.HasData(LoadStudents());
        }

        //private static List<Student> LoadStudents()
        //{
        //    return new List<Student>() {
        //        new Student {Id=1, Name="Fatima Ali"},
        //        new Student {Id=2, Name="Noor Saleh"},
        //        new Student {Id=3, Name="Omar Youssef"},
        //        new Student {Id=4, Name="Huda Ahmed"},
        //        new Student {Id=5, Name="Amira Tariq"},
        //        new Student {Id=6, Name="Zainab Ismail"},
        //        new Student {Id=7, Name="Youssef Farid"},
        //        new Student {Id=8, Name="Layla Mustafa"},
        //        new Student {Id=9, Name="Mohammed Adil"},
        //        new Student {Id=10, Name="Samira Nabil"},
        //    };
        //}
    }

}
