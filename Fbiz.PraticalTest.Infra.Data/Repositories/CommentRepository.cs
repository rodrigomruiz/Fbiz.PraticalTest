using System;
using System.Collections.Generic;
using Fbiz.PraticalTest.Domain.Entities;
using Fbiz.PraticalTest.Domain.Interfaces.Repositories;
using System.Linq;

namespace Fbiz.PraticalTest.Infra.Data.Repositories
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public IEnumerable<Comment> SearchByProduct(int productId)
        {
            return Db.Comments.Where(c => c.ProductId == productId);
        }
    }
}
