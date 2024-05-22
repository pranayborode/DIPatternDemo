using DIPatternDemo.Models;

namespace DIPatternDemo.Services
{
	public interface IStudentService
	{
		IEnumerable<Student> GetStudents();
		Student GetStudentById(int id);
		int AddStudent(Student student);
		int EditStudnet(Student student);
		int DeleteStudent(int id);
	}
}
