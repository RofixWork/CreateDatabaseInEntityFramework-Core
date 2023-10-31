
using EFMigration.Data;
using Microsoft.EntityFrameworkCore;

using (var _db = new AppDbContext())
{
	//   var enrollments = _db.Enrollments.Include(p => p.Section).Include(p => p.Student).Select(p => new {
	//       studentName = p.Student.Name,
	//       sectionName = p.Section.SectionName
	//   }).ToList();

	//foreach (var enrollment in enrollments)
	//{
	//       Console.WriteLine(enrollment.studentName + " Section: " + enrollment.sectionName);
	//   }

	var data = _db.Sections.Include(p => p.Course).Include(p => p.Schedule).Select(p => new
	{
		p.SectionName,
		p.Course.CourseName,
		p.Course.Price,
		p.Schedule.Title,
		p.TimeSlot.EndTime, p.TimeSlot.StartTime,
	}).ToList();
	 
	foreach (var item in data)
	{
        Console.WriteLine($"{item.SectionName} - ({item.StartTime} - {item.EndTime}) - {item.CourseName} - {item.Price:C} - {item.Title}");
    }
}