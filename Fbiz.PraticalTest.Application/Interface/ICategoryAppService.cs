using Fbiz.PraticalTest.Domain.Entities;
using System.Collections.Generic;

namespace Fbiz.PraticalTest.Application.Interface
{
    public interface ICategoryAppService : IAppServiceBase<Category>
    {
        IEnumerable<Category> SearchSpecialCategories();
    }
}
