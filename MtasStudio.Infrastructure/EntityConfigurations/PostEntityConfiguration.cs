using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MtasStudio.Domain.AggregateModels;
using MtasStudio.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtasStudio.Infrastructure.EntityConfigurations
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("posts", MtasDbContext.DEFAULT_SCHEMA);

            builder.HasKey(o => o.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Ignore(i => i.DomainEvents);

            builder.Property(i => i.Title)
                .HasColumnType("varchar")
                .HasMaxLength(250);
            builder.Property(i => i.Slug)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(i => i.Summary)
                .HasColumnType("varchar")
                .HasMaxLength(250);

            builder.Property(i => i.PostContents)
                .HasColumnType("text");

            
        }
    }
}
