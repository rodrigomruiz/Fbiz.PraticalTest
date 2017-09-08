using Fbiz.PraticalTest.Domain.Entities;
using System.Collections.Generic;

namespace Fbiz.PraticalTest.Domain.Interfaces.Services
{
    public interface ICategoryService : IServiceBase<Category>
    {
        IEnumerable<Category> SearchSpecialCategories(IEnumerable<Category> categories);
    }
    
}
