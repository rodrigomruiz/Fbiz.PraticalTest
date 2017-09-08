using System.Collections.Generic;

namespace Fbiz.PraticalTest.Store.ViewModels
{
    public class ProductCommentsViewModel
    {
        public virtual ProductViewModel Product { get; set; }
        public virtual IEnumerable<CommentViewModel> Comments { get; set; }
    }
}