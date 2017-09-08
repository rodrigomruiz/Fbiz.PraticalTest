using AutoMapper;
using Fbiz.PraticalTest.Application.Interface;
using Fbiz.PraticalTest.Domain.Entities;
using Fbiz.PraticalTest.Store.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Fbiz.PraticalTest.Store.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryAppService _categoryApp;

        public CategoriesController(ICategoryAppService categoryApp)
        {
            _categoryApp = categoryApp;
        }

        // GET: Categories
        public ActionResult Index()
        {
            var categoryViewModel = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(_categoryApp.GetAll());
            return View(categoryViewModel);
        }

        public ActionResult Special()
        {
            var categoryViewModel = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(_categoryApp.SearchSpecialCategories());
            return View(categoryViewModel);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            var category = _categoryApp.GetById(id);
            var categoryViewModel = Mapper.Map<Category, CategoryViewModel>(category);

            return View(categoryViewModel);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var categoryDomain = Mapper.Map<CategoryViewModel, Category>(category);
                _categoryApp.Add(categoryDomain);

                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _categoryApp.GetById(id);
            var clienteViewModel = Mapper.Map<Category, CategoryViewModel>(category);

            return View(clienteViewModel);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var categoryDomain = Mapper.Map<CategoryViewModel, Category>(category);
                _categoryApp.Update(categoryDomain);

                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _categoryApp.GetById(id);
            var clienteViewModel = Mapper.Map<Category, CategoryViewModel>(category);

            return View(clienteViewModel);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = _categoryApp.GetById(id);
            _categoryApp.Remove(category);

            return RedirectToAction("Index");
        }
    }
}
