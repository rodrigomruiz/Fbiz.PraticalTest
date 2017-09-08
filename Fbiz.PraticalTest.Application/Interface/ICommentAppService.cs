using Fbiz.PraticalTest.Domain.Entities;
using System.Collections.Generic;

namespace Fbiz.PraticalTest.Application.Interface
{
    public interface ICommentAppService : IAppServiceBase<Comment>
    {
        //IEnumerable<Comment> SearchByProduct(int productId);
        IEnumerable<Comment> SearchByProduct(int productId);
    }
}
