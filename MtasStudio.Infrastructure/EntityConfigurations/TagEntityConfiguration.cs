using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MtasStudio.Domain.AggregateModels;
using MtasStudio.Infrastructure.Context;

namespace MtasStudio.Infrastructure.EntityConfigurations
{
    public class TagEntityConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("tags", MtasDbContext.DEFAULT_SCHEMA);

            builder.HasKey(o => o.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Ignore(i => i.DomainEvents);

            builder.Property(i => i.Title)
                .HasColumnType("varchar")
                .HasMaxLength(250);
            builder.Property(i => i.Slug)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(i => i.Description)
                .HasColumnType("varchar")
                .HasMaxLength(250);

           
        
        }
    }
}
