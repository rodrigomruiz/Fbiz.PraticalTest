using System;
using System.Collections.Generic;
using Fbiz.PraticalTest.Application.Interface;
using Fbiz.PraticalTest.Domain.Entities;
using Fbiz.PraticalTest.Domain.Interfaces.Services;

namespace Fbiz.PraticalTest.Application
{
    public class CommentAppService : AppServiceBase<Comment>, ICommentAppService
    {
        private readonly ICommentService _commentService;

        public CommentAppService(ICommentService commentService)
            : base (commentService)
        {
            _commentService = commentService;
        }

        public IEnumerable<Comment> SearchByProduct(int productId)
        {
            return _commentService.SearchByProduct(productId);
        }
    }
}
