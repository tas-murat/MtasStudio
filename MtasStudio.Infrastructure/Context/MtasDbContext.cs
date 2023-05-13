using MediatR;
using Microsoft.EntityFrameworkCore;
using MtasStudio.Domain.AggregateModels;
using MtasStudio.Domain.SeedWork;
using MtasStudio.Infrastructure.EntityConfigurations;
using MtasStudio.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtasStudio.Infrastructure.Context
{
    public class MtasDbContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "mtasdb";
        private readonly IMediator mediator;

        public MtasDbContext() : base()
        {

        }
        public MtasDbContext(DbContextOptions<MtasDbContext> options, IMediator mediator) : base(options)
        {
            this.mediator = mediator;
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await mediator.DispatchDomainEventsAsync(this);
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TagEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PostCategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CommentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PostTagEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserOperationClaimEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OperationClaimEntityConfiguration());
        }
    }
}
