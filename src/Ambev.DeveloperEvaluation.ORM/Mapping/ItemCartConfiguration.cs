using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ItemCartConfiguration : IEntityTypeConfiguration<ItemCart>
{
    public void Configure(EntityTypeBuilder<ItemCart> builder)
    {
        builder.ToTable("ItemCarts");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.CartId).IsRequired().HasColumnType("uuid");
        builder.Property(u => u.ProductId).IsRequired().HasColumnType("uuid");
        builder.Property(u => u.Quantity).IsRequired().HasColumnType("int");

        builder.HasOne(u => u.Product)
               .WithMany()
               .HasForeignKey(u => u.ProductId);
    }
}