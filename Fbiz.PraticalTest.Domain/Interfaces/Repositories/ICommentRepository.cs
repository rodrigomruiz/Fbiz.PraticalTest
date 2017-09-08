using Fbiz.PraticalTest.Domain.Entities;
using System.Collections.Generic;

namespace Fbiz.PraticalTest.Domain.Interfaces.Repositories
{
    public interface ICommentRepository : IRepositoryBase<Comment>
    {
        IEnumerable<Comment> SearchByProduct(int productId);
    }
}
