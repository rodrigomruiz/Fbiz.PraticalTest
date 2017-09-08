using Fbiz.PraticalTest.Domain.Entities;
using System.Collections.Generic;

namespace Fbiz.PraticalTest.Application.Interface
{
    public interface IProductAppService : IAppServiceBase<Product>
    {
        IEnumerable<Product> SearchByName(string name);
        IEnumerable<Product> GetByActiveOrNotActive(bool active);
    }
}
