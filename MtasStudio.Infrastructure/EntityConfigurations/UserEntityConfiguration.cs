using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MtasStudio.Domain.AggregateModels;
using MtasStudio.Infrastructure.Context;

namespace MtasStudio.Infrastructure.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users", MtasDbContext.DEFAULT_SCHEMA);

            builder.HasKey(o => o.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Ignore(i => i.DomainEvents);

            builder.Property(i => i.FirstName)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder.Property(i => i.LastName)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(i => i.Email)
                .HasColumnType("varchar")
                .HasMaxLength(50);
        }
    }
}
