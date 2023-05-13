using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MtasStudio.Domain.AggregateModels;
using MtasStudio.Infrastructure.Context;

namespace MtasStudio.Infrastructure.EntityConfigurations
{
    public class UserOperationClaimEntityConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("useroperationclaims", MtasDbContext.DEFAULT_SCHEMA);

            builder.HasKey(o => o.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Ignore(i => i.DomainEvents);

        }
    }
}
