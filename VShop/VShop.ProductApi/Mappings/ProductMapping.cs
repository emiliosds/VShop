using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(o => o.Id);
        
        builder.Property(o => o.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(o => o.Description)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(o => o.ImageUrl)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(o => o.Price)
            .HasPrecision(12, 2);
    }
}