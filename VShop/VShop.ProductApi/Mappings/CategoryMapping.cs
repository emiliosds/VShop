using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Mappings;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(o => o.Products)
            .WithOne(o => o.Category)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new Category
            {
                Id = Guid.NewGuid(),
                Name = "Material Escolar"
            },
            new Category
            {
                Id = Guid.NewGuid(),
                Name = "Acessórios"
            }
        );
    }
}