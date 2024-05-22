using DIPatternDemo.Models;
using DIPatternDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIPatternDemo.Controllers
{
	public class StudentController : Controller
	{
		private readonly IStudentService service;

        public StudentController(IStudentService service)
        {
            this.service = service;
        }
        // GET: StudentController
        public ActionResult Index()
		{
			var model = service.GetStudents();
			return View(model);
		}

		// GET: StudentController/Details/5
		public ActionResult Details(int id)
		{
			var std = service.GetStudentById(id);

			return View(std);
		}

		// GET: StudentController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: StudentController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Student std)
		{
			try
			{
				int resut = service.AddStudent(std);
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

		// GET: StudentController/Edit/5
		public ActionResult Edit(int id)
		{
			var std = service.GetStudentById(id);
			return View(std);
		}

		// POST: StudentController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Student std)
		{
			try
			{
				int resut = service.EditStudnet(std);
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

		// GET: StudentController/Delete/5
		public ActionResult Delete(int id)
		{
			var emp = service.GetStudentById(id);

			return View(emp);
		}

		// POST: StudentController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{

			try
			{
				int resut = service.DeleteStudent(id);
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
