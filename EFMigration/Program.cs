
using EFMigration.Data;
using EFMigration.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

/*using (var _db = new AppDbContext())
{
	//   var enrollments = _db.Enrollments.Include(p => p.Section).Include(p => p.Student).Select(p => new {
	//       studentName = p.Student.Name,
	//       sectionName = p.Section.SectionName
	//   }).ToList();

	//foreach (var enrollment in enrollments)
	//{
	//       Console.WriteLine(enrollment.studentName + " Section: " + enrollment.sectionName);
	//   }

	//var data = _db.Sections.Include(p => p.Course).Include(p => p.Schedule).Select(p => new
	//{
	//	p.SectionName,
	//	p.Course.CourseName,
	//	p.Course.Price,
	//	p.Schedule.Title,
	//	p.TimeSlot.EndTime, p.TimeSlot.StartTime,
	//}).ToList();
	 
	//foreach (var item in data)
	//{
 //       Console.WriteLine($"{item.SectionName} - ({item.StartTime} - {item.EndTime}) - {item.CourseName} - {item.Price:C} - {item.Title}");
 //   }
}*/

using (var db = new AppDbContext())
{
	/*Participant participant1 = new Individual()
	{
		Id = 1,
		FName = "ahmed",
		LName = "ali",
		University = "xyz",
		YearOfGraduation = 2020,
		IsIntern = false
	};

    Participant participant2 = new Coporate()
    {
        Id = 2,
        FName = "amin",
        LName = "adil",
        JobTitle="developper",
		CompanyName="tyue"
    };

	db.Participants.AddRange(participant1, participant2);
	db.SaveChanges();*/

	var indivuals = db.Participants.OfType<Individual>().ToList();

	foreach (var item in indivuals)
	{
		Console.WriteLine(JsonSerializer.Serialize(item));
	}
}