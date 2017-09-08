using Fbiz.PraticalTest.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Fbiz.PraticalTest.Infra.Data.EntityConfig
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            HasKey(c => c.CommentId);

            HasRequired(c => c.Product)
                .WithMany()
                .HasForeignKey(c => c.ProductId);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.Text)
                .IsRequired();

            Property(c => c.Active)
                .IsRequired();
        }
    }
}
