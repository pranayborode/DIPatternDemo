using DIPatternDemo.Data;
using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly ApplicationDbContext db;
		public EmployeeRepository(ApplicationDbContext db)
		{
			this.db = db;
		}

		public int AddEmployee(Employee employee)
		{
			employee.IsActive = 1;
			int result = 0;
			db.Employees.Add(employee);
			result = db.SaveChanges();
			return result;
		}

		public int DeleteEmployee(int id)
		{
			int result = 0;
			var model = db.Employees.Where(e => e.Id == id).FirstOrDefault();

			if (model != null)
			{
				model.IsActive = 0;
				result = db.SaveChanges();

			}
			return result;
		}

		public int EditEmployee(Employee employee)
		{
			int result = 0;
			var model = db.Employees.Where(emp => emp.Id == employee.Id).FirstOrDefault();
			if (model != null)
			{
				model.Name = employee.Name;
				model.City = employee.City;
				model.Salary = employee.Salary;
				model.IsActive = 1;
				result = db.SaveChanges();
			}
			return result;

		}

		public Employee GetEmployeeById(int id)
		{
			return db.Employees.Where(x => x.Id == id).SingleOrDefault();

		}

		public IEnumerable<Employee> GetEmployees()
		{
			var model = (from emp in db.Employees
						 where emp.IsActive == 1
						 select emp).ToList();
			return model;

		}
	}
}
