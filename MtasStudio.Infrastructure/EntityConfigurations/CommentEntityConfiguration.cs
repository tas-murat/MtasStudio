using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MtasStudio.Domain.AggregateModels;
using MtasStudio.Infrastructure.Context;

namespace MtasStudio.Infrastructure.EntityConfigurations
{
    public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("comments", MtasDbContext.DEFAULT_SCHEMA);

            builder.HasKey(o => o.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Ignore(i => i.DomainEvents);

            builder.Property(i => i.CommentContents)
                .HasColumnType("varchar")
                .HasMaxLength(300);
            builder.Property(i => i.PostedBy)
                .HasColumnType("varchar")
                .HasMaxLength(100);




            builder.HasOne(c => c.Parent)
             .WithMany(c => c.Children)
             .HasForeignKey(c => c.ParentId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.ParentPost)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ParentPostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
