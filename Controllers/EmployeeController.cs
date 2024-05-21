using DIPatternDemo.Models;
using DIPatternDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIPatternDemo.Controllers
{
	public class EmployeeController : Controller
	{

		private readonly IEmployeeService service;

		public EmployeeController(IEmployeeService service)
		{
			this.service = service;
		}

		// GET: EmployeeController
		public ActionResult Index()
		{
			var model = service.GetEmployees();
			return View(model);
		}

		// GET: EmployeeController/Details/5
		public ActionResult Details(int id)
		{
			var emp = service.GetEmployeeById(id);

			return View(emp);
		}

		// GET: EmployeeController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: EmployeeController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Employee emp)
		{

			try
			{
				int resut = service.AddEmployee(emp);
				if (resut >= 1)
				{
					return RedirectToAction(nameof(Index));
				}
				else
				{
					ViewBag.ErrorMsg = "Somthing went wrong...";
					return View();
				}

			}
			catch (Exception ex)
			{
				ViewBag.ErrorMsg = ex.Message;
				return View();
			}
		}

		// GET: EmployeeController/Edit/5
		public ActionResult Edit(int id)
		{
			var emp = service.GetEmployeeById(id);
			return View(emp);
		}

		// POST: EmployeeController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Employee emp)
		{
			try
			{
				int resut = service.EditEmployee(emp);
				if (resut >= 1)
				{
					return RedirectToAction(nameof(Index));
				}
				else
				{
					ViewBag.ErrorMsg = "Somthing went wrong...";
					return View();
				}

			}
			catch (Exception ex)
			{
				ViewBag.ErrorMsg = ex.Message;
				return View();
			}
		}

		// GET: EmployeeController/Delete/5
		public ActionResult Delete(int id)
		{
			var emp = service.GetEmployeeById(id);

			return View(emp);
		}

		// POST: EmployeeController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				int resut = service.DeleteEmployee(id);
				if (resut >= 1)
				{
					return RedirectToAction(nameof(Index));
				}
				else
				{
					ViewBag.ErrorMsg = "Somthing went wrong...";
					return View();
				}

			}
			catch (Exception ex)
			{
				ViewBag.ErrorMsg = ex.Message;
				return View();
			}
		}
	}
}
