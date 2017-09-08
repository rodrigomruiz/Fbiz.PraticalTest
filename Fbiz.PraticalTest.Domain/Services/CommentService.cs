using System;
using System.Collections.Generic;
using Fbiz.PraticalTest.Domain.Entities;
using Fbiz.PraticalTest.Domain.Interfaces.Repositories;
using Fbiz.PraticalTest.Domain.Interfaces.Services;

namespace Fbiz.PraticalTest.Domain.Services
{
    public class CommentService : ServiceBase<Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
            : base(commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IEnumerable<Comment> SearchByProduct(int productId)
        {
            return _commentRepository.SearchByProduct(productId);
        }
    }
}
