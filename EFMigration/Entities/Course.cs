using System;
using System.Collections.Generic;
using System.Linq;
namespace EFMigration.Entities
{
    public record Course
    {
        public int Id { get; set; }
        public string? CourseName { get; set; }
        public decimal Price { get; set; }
        public ICollection<Section> Sections = new List<Section>();
    }
}
