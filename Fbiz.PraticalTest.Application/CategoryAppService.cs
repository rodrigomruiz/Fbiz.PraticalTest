using System;
using System.Collections.Generic;
using Fbiz.PraticalTest.Application.Interface;
using Fbiz.PraticalTest.Domain.Entities;
using Fbiz.PraticalTest.Domain.Interfaces.Services;

namespace Fbiz.PraticalTest.Application
{
    public class CategoryAppService : AppServiceBase<Category>, ICategoryAppService
    {
        private readonly ICategoryService _categoryService;

        public CategoryAppService(ICategoryService categoryService)
            : base(categoryService)
        {
            _categoryService = categoryService;
        }

        public IEnumerable<Category> SearchSpecialCategories()
        {
            return _categoryService.SearchSpecialCategories(_categoryService.GetAll());
        }
    }
}
