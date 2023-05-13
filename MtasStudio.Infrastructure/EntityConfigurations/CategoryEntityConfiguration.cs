using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MtasStudio.Domain.AggregateModels;
using MtasStudio.Infrastructure.Context;

namespace MtasStudio.Infrastructure.EntityConfigurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories", MtasDbContext.DEFAULT_SCHEMA);

            builder.HasKey(o => o.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Ignore(i => i.DomainEvents);

            builder.Property(i => i.Title)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder.Property(i => i.Slug)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(i => i.Description)
                .HasColumnType("varchar")
                .HasMaxLength(250);

            builder.HasIndex(x => x.Slug)
              .IsUnique();


            builder.HasOne(x => x.Parent)
           .WithMany(x => x.Children)
           .HasForeignKey(x => x.ParentId)
           .IsRequired(false);

            builder.HasMany(c => c.PostCategories)
                .WithOne(pc => pc.Category)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
