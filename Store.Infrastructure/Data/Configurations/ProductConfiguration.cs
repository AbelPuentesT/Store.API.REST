using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.Core.Enumerations;

namespace Store.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Product");

            builder.Property(e => e.Id);

            builder.Property(e => e.Category)
                .HasMaxLength(15)
                .IsRequired()
                .HasMaxLength(15)
                .HasConversion(
                x => x.ToString(),
                x => (Category)Enum.Parse(typeof(Category), x)
                );

            builder.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Image)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
