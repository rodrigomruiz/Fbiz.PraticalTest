using Fbiz.PraticalTest.Domain.Entities;
using System.Collections.Generic;

namespace Fbiz.PraticalTest.Domain.Interfaces.Services
{
    public interface ICommentService : IServiceBase<Comment>
    {
        IEnumerable<Comment> SearchByProduct(int productId);
    }
}
