namespace EFMigration.Entities
{
    public class Enrollment
    {
        public int StudentId { get; set; }
        public int SectionId { get; set; }
        public Participant? Participant { get; set; }
        public Section? Section { get; set; }
    }
}
