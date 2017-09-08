using Fbiz.PraticalTest.Application.Interface;
using Fbiz.PraticalTest.Infra.Data.Context;
using System.Web.Mvc;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using Fbiz.PraticalTest.Store.ViewModels;
using Fbiz.PraticalTest.Domain.Entities;
using PagedList;

namespace Fbiz.PraticalTest.Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductAppService _productApp;
        private PraticalTestContext db = new PraticalTestContext();

        public HomeController(IProductAppService productApp)
        {
            _productApp = productApp;
        }

        // GET: Active Products 
        public ViewResult Index(int? page, int? category)
        {
            int pageSize = 10;
            int numberPage = page ?? 1;

            var activeProducts = db.Products
                                    .Where(p => p.Active == true && 
                                    p.CategoryId == (category != null ? category : p.CategoryId))
                                    .OrderBy(p => p.Name);

            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(activeProducts);
            
            return View(productViewModel.ToPagedList(numberPage, pageSize));
        }
                
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}