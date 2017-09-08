using System;

namespace Fbiz.PraticalTest.Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }
        public virtual Product Product { get; set; }
    }
}
