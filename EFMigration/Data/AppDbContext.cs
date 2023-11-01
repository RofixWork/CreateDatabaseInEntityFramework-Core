using EFMigration.Data.Config;
using EFMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFMigration.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Section> Sections { get; set; } 
        public DbSet<Schedule> Schedules { get; set; } 
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Coporate> Coporates { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<MultipleChoiceQuiz> MultipleChoiceQuizzes { get; set; }
        public DbSet<TrueAndFalseQuiz> TrueAndFalseQuizzes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection")).LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfiguration).Assembly);
        }
    }
}
