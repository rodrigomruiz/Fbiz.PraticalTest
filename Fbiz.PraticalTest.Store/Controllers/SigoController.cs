using AutoMapper;
using Fbiz.PraticalTest.Application.Interface;
using Fbiz.PraticalTest.Domain.Entities;
using Fbiz.PraticalTest.Store.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Fbiz.PraticalTest.Store.Controllers
{
    public class SigoController : Controller
    {
        private readonly ICategoryAppService _categoryApp;
        
        public SigoController(ICategoryAppService categoryApp)
        {
            _categoryApp = categoryApp;
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var caterories = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(_categoryApp.GetAll());

            // Set up our ViewModel
            var viewModel = new TopMenuViewModel
            {
                FatherCategory = "Categorias Cadastradas",
                Categories = caterories
            };

            return PartialView("TopMenu", viewModel);
        }
    }
}