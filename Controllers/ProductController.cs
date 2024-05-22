using DIPatternDemo.Models;
using DIPatternDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIPatternDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;   
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var model = service.GetProducts();
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var model = service.GetProductById(id);
            return View(model);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product pro)
        {
            try
            {
                int resut = service.AddProduct(pro);
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = service.GetProductById(id);
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product pro)
        {
            try
            {
                int resut = service.EditProduct(pro);
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = service.GetProductById(id);
            return View(model);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int resut = service.DeleteProduct(id);
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
