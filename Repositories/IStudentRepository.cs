using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
	public interface IStudentRepository
	{
		IEnumerable<Student> GetStudents();
		Student GetStudentById(int id);
		int AddStudent(Student student);
		int EditStudnet(Student student);
		int DeleteStudent(int id);
	}
}
