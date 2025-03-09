using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.UserId).IsRequired().HasColumnType("uuid");
        builder.Property(u => u.Date).IsRequired().HasDefaultValueSql("now()");

        builder.HasOne(u => u.User)
               .WithMany()
               .HasForeignKey(u => u.UserId);

        builder.HasMany(u => u.Products)
               .WithOne()
               .HasForeignKey(u => u.CartId);
    }
}