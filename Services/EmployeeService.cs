using DIPatternDemo.Models;
using DIPatternDemo.Repositories;

namespace DIPatternDemo.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly IEmployeeRepository repo;

		public EmployeeService(IEmployeeRepository repo)
		{
			this.repo = repo;
		}
		public int AddEmployee(Employee employee)
		{
			return repo.AddEmployee(employee);
		}

		public int DeleteEmployee(int id)
		{
			return repo.DeleteEmployee(id);
		}

		public int EditEmployee(Employee employee)
		{
			return repo.EditEmployee(employee);
		}

		public Employee GetEmployeeById(int id)
		{
			return repo.GetEmployeeById(id);
		}

		public IEnumerable<Employee> GetEmployees()
		{
			return repo.GetEmployees();
		}
	}
}
