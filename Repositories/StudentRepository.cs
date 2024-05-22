using DIPatternDemo.Data;
using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
	public class StudentRepository : IStudentRepository
	{
		private readonly ApplicationDbContext db;
		public StudentRepository(ApplicationDbContext db)
		{
			this.db = db;
		}
		public int AddStudent(Student student)
		{
			student.IsActive = 1;
			int result = 0;
			db.Students.Add(student);
			result = db.SaveChanges();
			return result;
		}

		public int DeleteStudent(int id)
		{
			int result = 0;
			var model = db.Students.Where(e => e.Id == id).FirstOrDefault();

			if (model != null)
			{
				model.IsActive = 0;
				result = db.SaveChanges();

			}
			return result;
		}

		public int EditStudnet(Student student)
		{
			int result = 0;
			var model = db.Students.Where(s => s.Id == student.Id).FirstOrDefault();
			if (model != null)
			{
				model.Name = student.Name;
				model.Phone = student.Phone;
				model.Email = student.Email;
				model.Email = student.Address;
				model.IsActive = 1;
				result = db.SaveChanges();
			}
			return result;
		}

		public Student GetStudentById(int id)
		{
			return db.Students.Where(x => x.Id == id).SingleOrDefault();
		}

		public IEnumerable<Student> GetStudents()
		{
			var model = (from students in db.Students
						 where students.IsActive == 1
						 select students).ToList();
			return model;
		}
	}
}
