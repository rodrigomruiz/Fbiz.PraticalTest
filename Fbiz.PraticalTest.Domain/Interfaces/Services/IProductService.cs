using Fbiz.PraticalTest.Domain.Entities;
using System.Collections.Generic;

namespace Fbiz.PraticalTest.Domain.Interfaces.Services
{
    public interface IProductService : IServiceBase<Product>
    {
        IEnumerable<Product> SearchByName(string name);
        IEnumerable<Product> GetByActiveOrNotActive(bool active);
    }
}
