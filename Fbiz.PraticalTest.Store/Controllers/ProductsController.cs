using AutoMapper;
using Fbiz.PraticalTest.Application.Interface;
using Fbiz.PraticalTest.Domain.Entities;
using Fbiz.PraticalTest.Store.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Fbiz.PraticalTest.Store.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductAppService _productApp;
        private readonly ICategoryAppService _categoryApp;
        private readonly ICommentAppService _commentApp;
        
        public ProductsController(IProductAppService productApp, ICategoryAppService categoryApp, ICommentAppService commentApp)
        {
            _productApp = productApp;
            _categoryApp = categoryApp;
            _commentApp = commentApp;
        }

        // GET: Comments/GetProductComments/5
        public ViewResult GetProductComments(int id, int? page)
        {
            var product = _productApp.GetById(id);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(product);

            var coments = _commentApp.SearchByProduct(id);
            var productComments = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentViewModel>>(coments);
            
            // Set up our ViewModel
            var viewModel = new ProductCommentsViewModel
            {
                Product = productViewModel,
                Comments = productComments
            };

            return View(viewModel);       
        }

        // GET: Products
        public ActionResult Index()
        {
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(_productApp.GetAll());
            return View(productViewModel);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var product = _productApp.GetById(id);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(product);

            return View(productViewModel);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categoryApp.GetAll(), "CategoryId", "Name");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productDomain = Mapper.Map<ProductViewModel, Product>(product);
                _productApp.Add(productDomain);

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_categoryApp.GetAll(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productApp.GetById(id);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(product);

            ViewBag.CategoryId = new SelectList(_categoryApp.GetAll(), "CategoryId", "Name", productViewModel.CategoryId);

            return View(productViewModel);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productDomain = Mapper.Map<ProductViewModel, Product>(product);
                _productApp.Update(productDomain);

                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _productApp.GetById(id);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(product);

            return View(productViewModel);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _productApp.GetById(id);
            _productApp.Remove(product);
            
            return RedirectToAction("Index");
        }
    }
}
