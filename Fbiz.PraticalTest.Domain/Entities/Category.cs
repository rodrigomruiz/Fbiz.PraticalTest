using System;
using System.Collections.Generic;

namespace Fbiz.PraticalTest.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }
        public virtual IEnumerable<Product> Product { get; set; }

        public bool SpecialCategory(Category category)
        {
            return DateTime.Now.Year - category.RegistrationDate.Year > 1;
        }
    }
}
