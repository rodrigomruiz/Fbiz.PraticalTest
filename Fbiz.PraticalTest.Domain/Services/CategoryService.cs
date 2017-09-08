using System;
using System.Collections.Generic;
using Fbiz.PraticalTest.Domain.Entities;
using Fbiz.PraticalTest.Domain.Interfaces.Repositories;
using Fbiz.PraticalTest.Domain.Interfaces.Services;
using System.Linq;

namespace Fbiz.PraticalTest.Domain.Services
{
    public class CategoryService : ServiceBase<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
            : base (categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> SearchSpecialCategories(IEnumerable<Category> categories)
        {
            return categories.Where(c => c.SpecialCategory(c));
        }
    }
}
