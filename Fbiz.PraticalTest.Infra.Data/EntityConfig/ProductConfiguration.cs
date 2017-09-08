using Fbiz.PraticalTest.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Fbiz.PraticalTest.Infra.Data.EntityConfig
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(p => p.ProductId);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            HasRequired(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);

            Property(p => p.Active)
                .IsRequired();
        }
    }
}
