using Fbiz.PraticalTest.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Fbiz.PraticalTest.Infra.Data.EntityConfig
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasKey(c => c.CategoryId);

            Property(C => C.Name)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.Active)
                .IsRequired();            
        }
    }
}
