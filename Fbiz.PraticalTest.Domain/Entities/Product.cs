using System;

namespace Fbiz.PraticalTest.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Active{ get; set; }
        public virtual Category Category { get; set; }
    }
}
